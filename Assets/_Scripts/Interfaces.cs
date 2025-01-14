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
    Transform Owner { get; set; }
}

interface IInventory
{
    public void Store();
    public void Remove();
}
