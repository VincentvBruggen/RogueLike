using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    [SerializeField]
    Transform hand;

    [SerializeField]
    GameObject card;

    [SerializeField]
    TextMeshProUGUI deckAmountText;

    Stack<CardBase> s_Deck = new Stack<CardBase>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            s_Deck.Push(Instantiate(card, transform).GetComponent<CardBase>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        deckAmountText.text = s_Deck.Count.ToString();
    }

    public void PullHand()
    {
        StartCoroutine(Pull(hand.GetComponent<Inventory>().inventorySize));
    }

    private IEnumerator Pull(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CardBase card = s_Deck.Pop();

            card.transform.SetParent(hand);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
