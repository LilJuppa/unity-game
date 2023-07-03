using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_PotionShop : MonoBehaviour
{
    [SerializeField] Button Shop;
    [SerializeField] Button MainMenu;
    [SerializeField] Button Home;
    [SerializeField] Button AdventureGuild;
    [SerializeField] Button Arena;
    [SerializeField] Button Quit;
    [SerializeField] Button Combat;
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu)
            MainMenu.onClick.AddListener(GoMainMenu);
        if (Shop)
            Shop.onClick.AddListener(GoToPotionShop);
        if (Home)
            Home.onClick.AddListener(GoHome);
        if (AdventureGuild)
            AdventureGuild.onClick.AddListener(GoAdventureGuild);
        if (Quit)
            Quit.onClick.AddListener(QuitGame);
        if (Arena)
            Arena.onClick.AddListener(GoArena);
        if (Combat)
            Combat.onClick.AddListener(GoCombat);

    }

    private void GoToPotionShop()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.PotionShop);
    }

    private void GoMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }

    private void GoArena()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Arena);
    }

    private void GoCombat()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Combat);
    }

    private void GoHome()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Home);
    }

    private void GoAdventureGuild()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.AdventureGuild);
    }

    private void QuitGame()
    {
        ScenesManager.Instance.QuitGame();
    }
}

