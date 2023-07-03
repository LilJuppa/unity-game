using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToMap : MonoBehaviour
{
    [SerializeField] Button NewGame;
    // Start is called before the first frame update
    void Start()
    {
        NewGame.onClick.AddListener(StartNewGame);
        
    }

    private void StartNewGame() 
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Map);
        /*ScenesManager.Instance.LoadNewGame();*/
    }
}
