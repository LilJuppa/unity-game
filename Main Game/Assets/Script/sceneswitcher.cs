using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitcher: MonoBehaviour

{
    int curSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && curSceneIndex == 1)
        {

            SceneManager.LoadScene(0);
            return;

        }
        if (Input.GetMouseButtonDown(0) && curSceneIndex == 0)
        {

            SceneManager.LoadScene(1);
            return;

        }
    }

}
