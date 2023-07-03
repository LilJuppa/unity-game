using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    private static PlayerInfoManager instance;

    public delegate void OnPlayerInfoChange();
    public OnPlayerInfoChange onPlayerInfoCallBack;

    public static PlayerInfoManager GetInstance()
    {
        if (instance == null)
        {
            instance = new PlayerInfoManager();
            instance.init();
        }
        return instance;
    }

    public void InvokePlayerInfoCallback()
    {
        // Check if there are any subscribers to the event
        if (onPlayerInfoCallBack != null)
        {
            // Invoke the event
            onPlayerInfoCallBack.Invoke();
        }
    }
    public enum PlayerStats
    {
        Money,
        Strength,
        Intelligence,
        Faith,
        Charisma,
        Health,
        Mood,
        Insight
    };


    public string curPlayerName;


    public Dictionary<PlayerStats, int> playerstats = new();

    public void init()
    {
        GameDataManager gdm = GameDataManager.GetInstance();

        playerstats[PlayerStats.Money] = gdm.playerInfo.money;
        playerstats[PlayerStats.Strength] = gdm.playerInfo.strength;
        playerstats[PlayerStats.Intelligence] = gdm.playerInfo.intelligence;
        playerstats[PlayerStats.Faith] = gdm.playerInfo.faith;
        playerstats[PlayerStats.Charisma] = gdm.playerInfo.charisma;
        playerstats[PlayerStats.Insight] = gdm.playerInfo.Insight;


        curPlayerName = GameDataManager.GetInstance().playerInfo.name;
 
    }




    
}