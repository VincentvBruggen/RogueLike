using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    [SerializeField]
    GameObject[] cards;
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
        //// FOR DEBUGGING
        //for (int i = 0; i < 8; i++)
        //{
        //    s_Deck.Push(Instantiate(card, transform).GetComponent<CardBase>());
        //}
    }
    // Update is called once per frame
    void Update()
    {
        deckAmountText.text = s_Deck.Count.ToString();
    }

    // keep pulling cards from the deck until the maximum handsize is reached
    public void PullHand()
    {
        GameManager.instance.moneyAmount -= GameManager.instance.drawCost;
        Inventory handInv = hand.GetComponent<Inventory>();

        if(handInv.l_Cards.Count <= handInv.inventorySize )
        {
            StartCoroutine(Pull(handInv.inventorySize));
        }
        else
        {
            Debug.Log("hand full");
        }
    }

    // pull a card from the deck 
    private IEnumerator Pull(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //CardBase card = s_Deck.Pop();
            int rand = Random.Range(0, 1);

            GameObject cardObj = Instantiate(cards[rand]);
            
            CardBase card = cardObj.GetComponent<CardBase>();
            card.transform.SetParent(hand);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
