using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        GameDataManager.GetInstance().LoadGame("/Save1/GameInfo.txt");
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Map);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSave1()
    {
        GameDataManager.GetInstance().LoadGame("/GameInfo1.txt");
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Map);
    }
    public void LoadSave2()
    {
        GameDataManager.GetInstance().LoadGame("/GameInfo2.txt");
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Map);
    }
    public void LoadSave3()
    {
        GameDataManager.GetInstance().LoadGame("/GameInfo3.txt");
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Map);
    }
}
