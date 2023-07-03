using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUI : MonoBehaviour
{

    public StatsUI instance;

    public TMP_Text value;
    public PlayerInfoManager.PlayerStats basicStat;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        this.updateUI();

    }


    public void updateUI()
    {
        PlayerInfoManager PIM = PlayerInfoManager.GetInstance();
        value.text = PlayerInfoManager.GetInstance().playerstats[basicStat].ToString();
    }



}
