using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager
{
    #region Singleton
    public static ShopManager instance;

      public static ShopManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ShopManager();
            instance.initializeShop();
        }
        return instance;

    }

    #endregion

    

    public List<ItemContainerData> ItemContainerList = new List<ItemContainerData>();
    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryCallBack;

    private void initializeShop()
    {

        ItemContainerList = GameDataManager.GetInstance().shopItemDataInitial;

    }



    // Add = add item into ItemContainerList.
    public void Add(ItemContainerData newItemContainer)
    {

        // Search if duplicate in ItemList, if yes, quantity += 1 , return
        for (int i = 0; i < ItemContainerList.Count; i++)
        {
            if (ItemContainerList[i].itempath == newItemContainer.itempath)
            {
                ItemContainerList[i].quantity += newItemContainer.quantity;
                return;
            }
        }

        ItemContainerList.Add(newItemContainer);

    }

    // Remove = Remove (Use) one Item from ItemContainerList.
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
