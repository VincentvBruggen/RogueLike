using UnityEngine;

interface IDragable
{
    bool isDragging
    {
        get;
        set;
    }
    public void Drag();
}

interface IStoreable
{
    void StoreTo(Transform parent);
}

interface IBuyable
{
    void Buy();
}

interface IInventory
{
    public void Store(IStoreable storeable);
    public void Remove(IStoreable storeable);
}
