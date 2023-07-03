using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class ItemContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item thisItem;
    public string itemPath;
    public int Quantity = 1;
    public ItemState CurrentState = new();
    public int id;
    

    private Image image;

    private void Start()
    {
        //When start the game, render sprite of the attached object.
        image = GetComponent<Image>();
        reRenderSprite();

    }

    public void reRenderSprite()
    {
        
        if (thisItem == null && image != null)
        {
            Color newcolor = image.color;
            newcolor.a = 0f;
            image.sprite = null;
            image.color = newcolor;
            return;
        }

        if (thisItem && image)
        {
            

            image.sprite = thisItem.ItemImage;
            Color newcolor = image.color;
            newcolor.a = 1;
            image.color = newcolor;

        }

    }


    public enum ItemState
    {
        onTheGround,
        inShop,
        inInventory

    };

    //ItemState Function
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        PlayerInfoManager playerInfo = PlayerInfoManager.GetInstance();

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            switch (CurrentState)
            {
                case ItemState.onTheGround:
                    break;

                case ItemState.inShop:
                    //當物品狀態是在商店裡時
                    Debug.Log("My Money" + playerInfo.playerstats[PlayerInfoManager.PlayerStats.Money]);

                    if (playerInfo.playerstats[PlayerInfoManager.PlayerStats.Money] >= thisItem.Price)
                    {
                        playerInfo.playerstats[PlayerInfoManager.PlayerStats.Money] -= thisItem.Price;

                    }
                    else
                    {
                        Debug.Log("Not Enough Money");
                        return;
                    }
                    InventoryManager.GetInstance().Add(new ItemContainerData(itemPath, (int)CurrentState, 1));
                    InventoryManager.GetInstance().onInventoryCallBack();

                    ShopManager.GetInstance().Remove(new ItemContainerData(itemPath, (int)CurrentState, 1));
                    ShopManager.GetInstance().onInventoryCallBack();
                    TooltipManager._instance.HideToolTip();

                    break;
               
                case ItemState.inInventory:
                    //物品在背包裡 
                    if(thisItem)
                        thisItem.UseItem();
                    InventoryManager.GetInstance().Remove(new ItemContainerData(itemPath, (int)CurrentState, 1));
                    InventoryManager.GetInstance().onInventoryCallBack();
                    

                    break;

            }

        }
    }

    //Tooltip

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (thisItem != null)
        {
            
            TooltipManager._instance.SetAndShowToolTip(thisItem.ItemName, thisItem.ItemDescription, CurrentState.ToString());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideToolTip();

    }

   
}