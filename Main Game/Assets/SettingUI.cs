using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class SettingUI : MonoBehaviour
{
    public Button SettingButton;
    public Button closeButton;
    public GameObject SettingPanel;
    public TMP_Dropdown Resolution;
    public Toggle[] ScreenMode;
    private bool isInventoryOPen = false;


    // Start is called before the first frame update
    void Start()
    {
        SettingButton.onClick.AddListener(ToggleSetting);
        SettingPanel.SetActive(false);

        //Resolution.onValueChanged.AddListener(OnResolutionChanged);

        foreach (Toggle toggle in ScreenMode)
        {
            toggle.onValueChanged.AddListener(OnScreenModeChanged);
        }
    }

    void ToggleSetting()
    {
        isInventoryOPen = !isInventoryOPen;
        SettingPanel.SetActive(isInventoryOPen);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(SettingPanel.GetComponent<RectTransform>(), Input.mousePosition))
            {
                // 檢查點擊位置是否在UI元素上
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (isInventoryOPen)
                    {
                        ToggleSetting();

                    }
                }
            }
        }
    }

    private void OnScreenModeChanged(bool isOn)
    {
        Toggle activatedToggle = EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>();
        if (isOn)
        {
            Toggle activeToggle = null;

            foreach (Toggle toggle in ScreenMode)
            {
                if (toggle.isOn && toggle != activatedToggle)
                {
                    activeToggle = toggle;
                    break;
                }
            }

            if (activeToggle != null)
            {
                activeToggle.isOn = false;
            }
        }

    }

    //private void OnResolutionChanged(int resolution)
    //{
    //    // 取得選擇的解析度
    //    string resolutionStr = Resolution.options[resolution].text;
    //    string[] resolutionParts = resolutionStr.Split('x');
    //    int width = int.Parse(resolutionParts[0]);
    //    int height = int.Parse(resolutionParts[1]);

    //    // 設置選擇的解析度
    //    Screen.SetResolution(width, height, Screen.fullScreenMode);
    //}
}
