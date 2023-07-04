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
            instance.Init();
        }
            
        return instance;
    }
    //private Dictionary<int, ItemContainerData> iteminfo = new();
    public List<ItemContainerData> shopItemDataInitial = new();

    //玩家信息存儲路徑
    private static string PlayerInfo_Path = Application.persistentDataPath + "/PlayerInfo.txt";
    public Player playerInfo;



    public void Init()
    {
        string shopdatastring = Resources.Load<TextAsset>("Json/ShopItemContainer").text;
        ItemContainerDatas ContainerItemData = JsonUtility.FromJson<ItemContainerDatas>(shopdatastring);



        for (int i = 0; i < ContainerItemData.shopdata.Count; ++i)
        {
            //if (!iteminfo.ContainsKey(ContainerItemData.shopdata[i].id))
            //{
            //    iteminfo.Add(ContainerItemData.shopdata[i].id, ContainerItemData.shopdata[i]);
                
            //}
            shopItemDataInitial.Add(ContainerItemData.shopdata[i]);

        }

        //初始化 角色信息
        if (File.Exists(PlayerInfo_Path))
        {
            //讀出指定路徑的文件，轉成string，再轉成玩家的數據
            byte[] bytes = File.ReadAllBytes(PlayerInfo_Path);
            string json = Encoding.UTF8.GetString(bytes);
            playerInfo = JsonUtility.FromJson<Player>(json);

        }
        else
        {
            Debug.Log("Player info don't exist");
            //沒有玩家數據時，初始化一個默認數據
            playerInfo = new Player();
            //並存儲
            SavePlayerInfo();
        }

        PlayerInfoManager.GetInstance().init();
    }

    //保存玩家信息
    public void SavePlayerInfo()
    {
        Debug.Log("Creating a new save file");
        string json = JsonUtility.ToJson(playerInfo);
        File.WriteAllBytes(PlayerInfo_Path, Encoding.UTF8.GetBytes(json));
    }

    //public ItemContainerData GetItemInfo(int id)
    //{
    //    if (iteminfo.ContainsKey(id))
    //        return iteminfo[id];
    //    return null;
    //}
}





    //Player Basic Info
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



    public class ItemContainerDatas
    {
        //employees is case sensitive and must match the string "employees" in the JSON.
        public List<ItemContainerData> shopdata;

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

