using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public float maxhp;
    public float damage;
    public float defense;
    public TMP_Text healthbar;
    public TMP_Text damageTaken;
    private float duration = 0;
    // Start is called before the first frame update
    private void Start()
    {
        hp = maxhp;
        
    }

    private void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else if(duration <= 0 && damageTaken.gameObject.activeSelf)
        {
            damageTaken.gameObject.SetActive(false);
        }
    }

    public void hurt(float damage)
    {
        hp -= damage;
        damageTaken.gameObject.SetActive(true);
        damageTaken.text = "-" + damage.ToString();
        healthbar.text = hp.ToString();
        duration = 1;
        if(hp <= 0)
        {
            win();
        }
    }

    public void win()
    {
        Destroy(this.gameObject);
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Arena);
    }
}
