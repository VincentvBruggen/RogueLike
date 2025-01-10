using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private float width = 5f;

    [SerializeField, MinMaxSlider(0f, 1f)]
    private float lerpSpeed = 0.1f;

    List<CardBase> l_Cards = new List<CardBase>();
    //Coroutine coroutine;
    void Start()
    {
        StartCoroutine(AlignContent());
    }

    void Update()
    {
        //if (coroutine == null) 
        //{ 
        //    coroutine = StartCoroutine(AlignContent());
        //}
        //FOR DEBUGGING
        foreach (Transform cardObj in transform)
        {
            CardBase card = cardObj.GetComponent<CardBase>();
            if (card != null && card != l_Cards.Contains(card))
            {
                l_Cards.Add(card.GetComponent<CardBase>());
            }
        }
    }

    private IEnumerator AlignContent()
    {
        while (true)
        {
            // If there is only 1 card in the inventory, place it in the center
            if(l_Cards.Count <= 1)
            {
                foreach(CardBase card in l_Cards)
                {
                    card.transform.position = transform.position;
                }
                yield break;
            }

            // Give all the cards an even spacing from each other
            float lerpTimer = 0f;
            while(lerpTimer < 1f)
            {
                float spacing = (GetMaxWidth().x - GetMinWidth().x) / (l_Cards.Count - 1);
                for (int i = 0; i < l_Cards.Count; i++)
                {
                    Vector3.Lerp(l_Cards[i].transform.position,
                        new Vector3(GetMinWidth().x + (spacing * i), transform.position.y, transform.position.z),
                        lerpTimer
                        );
                }

                lerpTimer += lerpSpeed;
                yield return new WaitForSeconds(lerpSpeed);
            }
            yield return new WaitForSeconds(0.1f);
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
