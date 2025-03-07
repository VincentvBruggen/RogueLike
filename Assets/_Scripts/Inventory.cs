using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    [NonSerialized]
    public List<CardBase> l_Cards = new List<CardBase>();

    public int inventorySize = 5;

    [SerializeField]
    TextMeshProUGUI inventorySizeText;

    [SerializeField]
    private float width = 5f;

    [SerializeField, Range(5f, 20f)]
    private float lerpSpeed = 0.1f;


    void Start()
    {

    }

    void IInventory.Store(IStoreable storeable)
    {
        storeable.StoreTo(transform);
        
        foreach (Transform cardObj in transform)
        {
            CardBase card = cardObj.GetComponent<CardBase>();
            if (card != null && card != l_Cards.Contains(card))
            {
                l_Cards.Add(card);
            }
        }
    }   
    void IInventory.Remove(IStoreable storeable)
    {

    }

    void Update()
    {

        //FOR DEBUGGING
        foreach (Transform cardObj in transform)
        {
            CardBase card = cardObj.GetComponent<CardBase>();
            if (card != null && card != l_Cards.Contains(card))
            {
                l_Cards.Add(card);
            }
        }

        inventorySizeText.text = l_Cards.Count.ToString() + "/" + inventorySize.ToString();
        AlignContent();
    }

    private void AlignContent()
    {

        // If there is only 1 card in the inventory, place it in the center
        if(l_Cards.Count <= 1)
        {
            foreach(CardBase card in l_Cards)
            {
                if (!card.isDragging) // when a card is not being dragged
                {
                    card.transform.position = Vector3.Lerp(card.transform.position,
                    transform.position,
                    lerpSpeed * Time.deltaTime
                    );
                }
                
            }
            return;
        }

        // Give all the cards an even spacing from each other

        float spacing = (GetMaxWidth().x - GetMinWidth().x) / (l_Cards.Count - 1);
        for (int i = 0; i < l_Cards.Count; i++)
        {
            if (!l_Cards[i].isDragging) // when a card is not being dragged 
            {
                l_Cards[i].transform.position = Vector3.Lerp(l_Cards[i].transform.position,
                new Vector3(GetMinWidth().x + (spacing * i), transform.position.y, transform.position.z),
                lerpSpeed * Time.deltaTime
                );
            }
            
        }      
    }

    // Get the most left position from the field
    private Vector3 GetMinWidth()
    {
        return transform.position - (Vector3.left * -width / 2);
    }

    // Get the most right position from the field
    private Vector3 GetMaxWidth()
    {
        return transform.position - (Vector3.right * -width / 2);
    }

    // For Debugging draw the field as a box
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, Vector3.right * width + Vector3.up * 2);
    }
}
