using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ScheduleActivate : MonoBehaviour
{
    public Button ScheduleButton;
    public Button closeBurron;
    public GameObject SchedulePanel;
    private bool isScheduleOPen = false;

    void Start()
    {
        ScheduleButton.onClick.AddListener(ToggleSchedule);
        SchedulePanel.SetActive(false);
    }

    void ToggleSchedule()
    {
        isScheduleOPen = !isScheduleOPen;
        SchedulePanel.SetActive(isScheduleOPen);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 檢查點擊位置是否在背包panel上
            if (!RectTransformUtility.RectangleContainsScreenPoint(SchedulePanel.GetComponent<RectTransform>(), Input.mousePosition))
            {
                // 檢查點擊位置是否在UI元素上
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (isScheduleOPen)
                    {
                        ToggleSchedule();

                    }
                }
            }
        }
    }

}