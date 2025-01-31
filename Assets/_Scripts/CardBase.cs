using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour, IDragable, IStoreable
{
    public GameObject obj;
    public bool isDragging { get; set; }
    
    public Transform Owner {  get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // a function for storing the card to an inventory
    public void StoreTo(Transform parent)
    {
        transform.SetParent(parent);
    }

    public virtual void Drag()
    {
        GameManager.instance.cardToPlace = obj;
        Destroy(gameObject);
    }

    // a function for changing the overlap of the cards
    public void SetDrawOrder()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {

        }
    }

    private void OnMouseDown()
    {
        Drag();
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
}
