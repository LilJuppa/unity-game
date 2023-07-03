using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public ItemSlot[] ItemSlots;
    public Transform InventoryParent;


    private void Start()
    {
        //onInventoryCallBack subcribe UpdateUI, so whenever I call onInventoryCallBack, UpdateUI will also execute.
        ShopManager.GetInstance().onInventoryCallBack += UpdateUI;
        ItemSlots = InventoryParent.GetComponentsInChildren<ItemSlot>();
        UpdateUI();

    }

    public void UpdateUI()
    {
        //look through every inventory slots, add item from ShopManager ItemList
        
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            
            //check ItemList, when there is an object, add item to the Shop slot, if the item removed, clean out the slot.
            if (i < ShopManager.GetInstance().ItemContainerList.Count)
            {
                
                ItemSlots[i].AddItemContainer(ShopManager.GetInstance().ItemContainerList[i]);

            }  
            else
            {
                ItemSlots[i].Clean();
            }
        }
    }
}
