using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MainPanel : MonoBehaviour
{
    public Button inventoryButton;
    public Button closeInventory;
    public GameObject inventoryPanel;
    private bool isInventoryOPen = false; 

    void Start()
    {
        inventoryButton.onClick.AddListener(ToggleInventory);
        inventoryPanel.SetActive(false);
    }

    void ToggleInventory()
    {
        isInventoryOPen = !isInventoryOPen;
        inventoryPanel.SetActive(isInventoryOPen);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 檢查點擊位置是否在背包panel上
            if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel.GetComponent<RectTransform>(), Input.mousePosition))
            {
                // 檢查點擊位置是否在UI元素上
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (isInventoryOPen)
                    {
                        ToggleInventory();

                    }
                }
            }
        }
    }

}
