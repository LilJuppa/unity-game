using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemSystem/Class")]
public class Class : ScriptableObject
{
    public int ClassID;
    public string ClassName;
    public Image ClassImage;
    public int StatsAmount;
    public StatsType type;


    public enum StatsType
    {
        Intelligence,
        Strength,
        Faith,
        Charisma,
        Insight

    };

    public virtual void UseItem()
    {

        // Methods to use item
    }
}
