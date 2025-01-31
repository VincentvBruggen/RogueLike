using UnityEngine;

public class CornerCard : CardBase
{
    
    public override void Drag()
    {
        GameManager.instance.cardToPlace = obj;
    }
}
