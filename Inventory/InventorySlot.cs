﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot 
{
    public Stack<IInventoryItem> mItemStack = new Stack<IInventoryItem>();
    private int mId = 0;

    public InventorySlot(int Id)
    {
        mId = Id;
    }

    public int Id
    {
        get { return mId; }
    }

    

    public void AddItem(IInventoryItem item)
    {
        item.Slot = this;
        mItemStack.Push(item);
    }
    public int Count
    {
        get { return mItemStack.Count; }
    }
    public bool IsEmpty
    {
        get { return Count == 0; }
    }
    public IInventoryItem FistItem
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }
            return mItemStack.Peek();
        }
    }

    public bool IsStackable(IInventoryItem item)
    {
        if (IsEmpty)
        {
            return false;
        }
        IInventoryItem first = mItemStack.Peek();
        if (first.Name==item.Name)
        {
            return true;
        }
        return false;
    }

    public bool Remove(IInventoryItem item)
    {
        if(IsEmpty)
        {
            return false;
        }

        IInventoryItem first = mItemStack.Peek();
        if(first.Name==item.Name)
        {
            mItemStack.Pop(); //pop=ดึงออก
            return true;
        }
        return false;
    }
}
