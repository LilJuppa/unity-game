using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.onClick.AddListener(LoadMainMenu);

    }

    private void LoadMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
        /*ScenesManager.Instance.LoadNewGame();*/
    }

}
