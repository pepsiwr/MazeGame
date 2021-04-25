using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //จำเป็น

public class HUD : MonoBehaviour
{
    public Inventory inventory;
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender,InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++; //อันแรกIndex=0

            Transform imageTranform = slot.GetChild(0).GetChild(0); //ตำแหน่งใน Group ใน Hierarchy
            //Transform textTranform = slot.GetChild(0).GetChild(1);  //ตำแหน่งใน Group ใน Hierarchy

            Image image = imageTranform.GetComponent<Image>(); //ให้โชว์รูปอะไรในช่องเก็บของ
            //Text txtCount = textTranform.GetComponent<Text>();

            if (index==e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image; //ชนไอเทมไหนโชว์ไอเทมนั้น

                int itemCount = e.Item.Slot.Count;
                /*if (itemCount>1)
                {
                    txtCount.text = itemCount.ToString();
                }
                else
                {
                    txtCount.text = "";
                }
                break;*/
            }
        }
    }

    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++; //อันแรกIndex=0

            Transform imageTranform = slot.GetChild(0).GetChild(0); //ตำแหน่งใน Group ใน Hierarchy
            //Transform textTranform = slot.GetChild(0).GetChild(1);  //ตำแหน่งใน Group ใน Hierarchy

            Image image = imageTranform.GetComponent<Image>(); //ให้โชว์รูปอะไรในช่องเก็บของ
            //Text txtCount = textTranform.GetComponent<Text>();

            if (index == e.Item.Slot.Id)
            {
                int itemCount = e.Item.Slot.Count;
                /*if(itemCount<2)
                {
                    txtCount.text = "";
                }
                else
                {
                    txtCount.text = itemCount.ToString();
                }*/

                if(itemCount==0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }

                break;
            }
        }
    }
}
