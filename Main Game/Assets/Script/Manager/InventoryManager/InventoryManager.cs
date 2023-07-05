using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    #region Singleton
    private static InventoryManager instance;

    public static InventoryManager GetInstance()
    {
        if (instance == null)
        {
            instance = new InventoryManager();
            instance.initializeInventory();
        }
        return instance;
    }

    #endregion

    public List<ItemContainerData> ItemContainerList = new List<ItemContainerData>();
    public delegate void OnInventoryChange();

    public OnInventoryChange onInventoryCallBack;

    //設置打開inventory時包包裡裝的物品
    public void initializeInventory()
    {
        ItemContainerList = GameDataManager.GetInstance().playerInfo.items;
    }



    // Add = add item into ItemList.
    public void Add(ItemContainerData newItemContainer)
    {
        
        // Search if duplicate in ItemList, if yes, quantity += newitemquantity , return
        for (int i = 0; i < ItemContainerList.Count; i++)
        {
            if (ItemContainerList[i].itempath == newItemContainer.itempath)
            {
                ItemContainerList[i].quantity += newItemContainer.quantity;
                return;
            }
        }

        ItemContainer.ItemState newState = ItemContainer.ItemState.inInventory;
        newItemContainer.currentstate = (int)newState;
        ItemContainerList.Add(newItemContainer);
 
    }

    // Remove = Remove (Use) one Item from ItemList.
    public void Remove(ItemContainerData oldItemContainer)
    {
        // Search if duplicate in ItemContainerList, if yes, quantity -= 1 , return
        for (int i = 0; i < ItemContainerList.Count; i++)
        {
            if (ItemContainerList[i].itempath == oldItemContainer.itempath)
            {
                ItemContainerList[i].quantity -= 1;
                if (ItemContainerList[i].quantity <= 0)
                {
                    ItemContainerList.RemoveAt(i);
                }
                return;
            }
        }
    }

    
}
