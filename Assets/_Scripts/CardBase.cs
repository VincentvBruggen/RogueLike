using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour, IDragable
{
    public bool isDragging { get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drag()
    {
        
    }

    public void SetDrawOrder()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {

        }
    }
}
