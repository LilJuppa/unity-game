using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public ItemContainer itemcontainer;
    public TMP_Text itemQuantity;
    public TMP_Text itemPrice;


    public void AddItemContainer(ItemContainerData newItemContainer)
    {
        itemcontainer.thisItem = Resources.Load<Item>(newItemContainer.itempath);


        itemcontainer.Quantity = newItemContainer.quantity;
        itemcontainer.CurrentState = (ItemContainer.ItemState)newItemContainer.currentstate;
        itemcontainer.itemPath = newItemContainer.itempath;
        itemcontainer.reRenderSprite();
        itemQuantity.text = itemcontainer.Quantity.ToString();

        switch (itemcontainer.CurrentState)
        {
            case ItemContainer.ItemState.inShop:
                if (itemPrice != null)
                {
                    itemPrice.text = "$" + itemcontainer.thisItem.Price.ToString();
                }
                break;

            case ItemContainer.ItemState.inInventory:

                break;
        }
   
            
    }

    public void RemoveItem()
    {

        ItemContainer.ItemState tempState = itemcontainer.CurrentState;


        ItemContainerData temp = new ItemContainerData(itemcontainer.itemPath, (int)tempState, itemcontainer.Quantity);
        ShopManager.GetInstance().Remove(temp);
        ShopManager.GetInstance().onInventoryCallBack();
        itemPrice.text = "";
        itemQuantity.text = "";
    }


    public void Clean()
    {
        itemcontainer.thisItem = null;
        if(itemPrice)
            itemPrice.text = "";
        itemQuantity.text = "";
        itemcontainer.reRenderSprite();
        
    }

    public void UseItem()
    {
        if (itemcontainer != null && itemcontainer.thisItem != null)
        {
            itemcontainer.thisItem.UseItem();
            RemoveItem();
            TooltipManager._instance.HideToolTip();
        }
        else
        {
            return;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         // Forward the pointer enter event to the contained ItemContainer
        if (itemcontainer != null)
        {
            itemcontainer.OnPointerEnter(eventData);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Forward the pointer exit event to the contained ItemContainer
        if (itemcontainer != null)
        {
            itemcontainer.OnPointerExit(eventData);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (itemcontainer != null)
            {
                itemcontainer.OnPointerClick(pointerEventData);
            }
        }
    }
}
