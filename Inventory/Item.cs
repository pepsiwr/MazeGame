using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInventoryItem
{
    public string _name = "item";
    public Sprite _image = null;
    public Vector3 PickPosition;
    public Vector3 PickRotation;


    public string Name
    {
        get { return _name; }
    }
    public Sprite Image
    {
        get { return _image; }
    }
    public InventorySlot Slot
    {
        get;
        set;
    }
    public void OnPickup()
    {
        gameObject.SetActive(false); //ถ้าชนสิ่งของ SetActive จะเป็น False
    }
    public virtual void OnUse()
    {
        //gameObject.SetActive(true);
        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotation;
    }
    
}
