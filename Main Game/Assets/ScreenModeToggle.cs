using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScreenModeToggle : MonoBehaviour
{
    public Toggle fullscreen;
    public Toggle windowed;

    // Start is called before the first frame update
    void Start()
    {
        fullscreen.onValueChanged.AddListener(ToggleFullscreen);
        windowed.onValueChanged.AddListener(ToggleWindowed);
    }

    // Update is called once per frame
    private void ToggleFullscreen(bool isOn)
    {
        // 根據 Toggle 的狀態切換屏幕模式
        if (isOn)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }

    }

    private void ToggleWindowed(bool isOn)
    {
        // 根據 Toggle 的狀態切換屏幕模式
        if (isOn)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
}
