

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    public enum Scene {
        MainMenu,
        Map,
        ShopScene,
        PotionShop,
        Home,
        AdventureGuild,
        Arena,
        Combat
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());

    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Map.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }
}
