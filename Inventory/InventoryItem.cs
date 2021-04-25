using System; //จำเป็น
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem 
{
    string Name { get; } //ชื่อ
    Sprite Image { get; } //รูป
    InventorySlot Slot { get; set; }
    void OnPickup();
    void OnUse();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }
    public IInventoryItem Item;
}
