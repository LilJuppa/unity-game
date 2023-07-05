using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


public class GameDataManager 
{
    private static GameDataManager instance;

    public static GameDataManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameDataManager();
        }
            
        return instance;
    }

    //玩家信息存儲路徑
    private static string GameInfo_Path = Application.persistentDataPath + "/GameInfo.txt";

    
    public Player playerInfo;
    public GameInfo gameInfo;
    public ItemContainerDatas shopItemData;

    public void SaveGameInfo()
    {
        Debug.Log("Creating a new save file");
        gameInfo = new GameInfo(playerInfo, shopItemData);
        string json = JsonUtility.ToJson(gameInfo);
        File.WriteAllText(GameInfo_Path, json);
    }

    public void LoadGame(string savePath)
    {
        GameInfo_Path = Application.persistentDataPath + savePath;
        if (File.Exists(GameInfo_Path))
        {
            //byte[] bytes = File.ReadAllBytes(PlayerInfo_Path);
            string json = File.ReadAllText(GameInfo_Path);
            gameInfo = JsonUtility.FromJson<GameInfo>(json);
        }
        else
        {
            Debug.Log("Game info don't exist");
            gameInfo = new GameInfo();
            SaveGameInfo();
        }
        playerInfo = gameInfo.playerinfo;
        shopItemData = gameInfo.shopItemData;

        PlayerInfoManager.GetInstance().init();
        ShopManager.GetInstance().initializeShop();
    }
}



public class GameInfo
{
    public Player playerinfo;
    public ItemContainerDatas shopItemData;
    public GameInfo()
    {
        playerinfo = new Player();
        shopItemData = new ItemContainerDatas();
    }
    public GameInfo(Player newPlayer, ItemContainerDatas newItems)
    {
        playerinfo = newPlayer;
        shopItemData = newItems;
    }
}


[System.Serializable]    //Player Basic Info
public class Player
{
    public string name;
    public int EXP;
    public int Lv;
    public int money;
    public int strength;
    public int intelligence;
    public int faith;
    public int charisma;
    public int Insight;
    public List<ItemContainerData> items;

    public Player()
    {
        name = "Juppa";
        money = 9999;
        strength = 100;
        intelligence = 100;
        faith = 100;
        charisma = 0;
        Insight = 0;
        
        items = new List<ItemContainerData>()
        {
            new ItemContainerData("ItemAsset/Potion/BloodPotion", 2, 1),
            new ItemContainerData("ItemAsset/Potion/BluePotion", 2, 2),
            new ItemContainerData("ItemAsset/Potion/GreenPotion", 2, 3)
        };
    }
}


[System.Serializable]
public class ItemContainerDatas
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public List<ItemContainerData> shopdata;

    public ItemContainerDatas()
    {
        shopdata = new List<ItemContainerData>()
        {
            new ItemContainerData("ItemAsset/Potion/BloodPotion", 1, 1),
            new ItemContainerData("ItemAsset/Potion/BluePotion", 1, 2),
            new ItemContainerData("ItemAsset/Potion/GreenPotion", 1, 3)
        };
    }

    public ItemContainerDatas(List<ItemContainerData> newList)
    {
        shopdata = newList;
    }



}


[System.Serializable]
public class ItemContainerData
{

    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string itempath;
    public int currentstate;
    public int quantity = 1;
    public bool israndom = false;
    public int randomstart = 0;
    public int randomend = 0;
        

        

    public ItemContainerData(string _itempath, int _currentstate, int _quantity)
    {
        itempath = _itempath;
        currentstate = _currentstate;
        quantity = _quantity;      
    }

}


