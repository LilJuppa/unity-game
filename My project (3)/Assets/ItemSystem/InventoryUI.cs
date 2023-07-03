using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemSlot[] ItemSlots;
    public Transform InventoryParent;

    private void Start()
    {
        //onInventoryCallBack subcribe UpdateUI, so whenever I call onInventoryCallBack, UpdateUI will also execute.
        InventoryManager.GetInstance().onInventoryCallBack += UpdateUI;
        ItemSlots = InventoryParent.GetComponentsInChildren<ItemSlot>();
        UpdateUI();

    }

    
    public void UpdateUI()
    {
       //look through every inventory slots, add item from IventoryManager ItemList
        for (int i =0; i < ItemSlots.Length; i++)
        {
            //check ItemList, when there is an object, add item to the inventory slot, if the item removed, clean out the slot.
            if (i < InventoryManager.GetInstance().ItemContainerList.Count)
            {
                ItemSlots[i].AddItemContainer(InventoryManager.GetInstance().ItemContainerList[i]);

            }
            else
            {
                ItemSlots[i].Clean();
            }
        }
    }
}
