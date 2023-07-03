using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsPanel : MonoBehaviour
{
    public StatsUI[] UIslots;
    public Transform InventoryParent;


    private void Start()
    {
        Debug.Log("Pannel Started");
        //onInventoryCallBack subcribe UpdateUI, so whenever I call onInventoryCallBack, UpdateUI will also execute.
        PlayerInfoManager.GetInstance().onPlayerInfoCallBack += UpdateUI;
        UIslots = InventoryParent.GetComponentsInChildren<StatsUI>();
        UpdateUI();

    }

    public void UpdateUI()
    {
        //look through every inventory slots, add item from ShopManager ItemList

        for (int i = 0; i < UIslots.Length; i++)
        {
            UIslots[i].updateUI();
        }
    }
}
