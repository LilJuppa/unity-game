using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Button TestButton;
    public Enemy enemy;
    void Start()
    {
        TestButton.onClick.AddListener(() => enemy.hurt(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
