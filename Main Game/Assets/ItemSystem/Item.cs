using UnityEngine;

[CreateAssetMenu(menuName = "ItemSystem/Item")]
public class Item : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemImage;
    public bool Stackable;
    public string ItemDescription;
    public int Price;
    public ItemType type;
    
    public int increaseStrengthBy;
    public int increaseIntellegenceBy;
    public int increaseFaithBy;



    public enum ItemType
    {
        StatConsumeable,
        other

    };

    public virtual void UseItem()
    {
        switch (type)
        {
            case ItemType.StatConsumeable:

                PlayerInfoManager.GetInstance().playerstats[PlayerInfoManager.PlayerStats.Strength] += increaseStrengthBy;
                PlayerInfoManager.GetInstance().playerstats[PlayerInfoManager.PlayerStats.Intelligence] += increaseIntellegenceBy;
                PlayerInfoManager.GetInstance().playerstats[PlayerInfoManager.PlayerStats.Faith] += increaseFaithBy;

                PlayerInfoManager.GetInstance().InvokePlayerInfoCallback();
                break;

        }
        // Methods to use item
    }
}