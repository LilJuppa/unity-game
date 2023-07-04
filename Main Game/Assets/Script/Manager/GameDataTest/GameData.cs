using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public int strength;
    public int intelligence;
    public int dexterity;
}

[System.Serializable]
public class GameSettings
{
    public float soundVolume;
    public int graphicsQuality;
    // Add more settings properties as needed
}

[System.Serializable]
public class Inventory
{
    public List<ItemData> items;

    public Inventory()
    {
        items = new List<ItemData>();
    }
}

[System.Serializable]
public class ItemData
{
    public string itemName;
    public int quantity;
    // Add more item properties as needed
}

[System.Serializable]
public class SavedData
{
    public string playerStatsJson;
    public string gameSettingsJson;
    public string inventoryJson;

    public SavedData(string playerStatsJson, string gameSettingsJson, string inventoryJson)
    {
        this.playerStatsJson = playerStatsJson;
        this.gameSettingsJson = gameSettingsJson;
        this.inventoryJson = inventoryJson;
    }
}
