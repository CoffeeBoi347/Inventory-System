using UnityEngine;

[CreateAssetMenu(fileName = "ItemAsset", menuName = "Items", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemPoints;
    public Sprite itemSprite;
    public ItemType itemType;
}

public enum ItemType
{
    Sword,
    ArmorBody,
    ArmorHelmet,
    ArmorLegs,
    Ak47,
    Shotgun,
    Apple,
    Banana,
    Cherry,
    Mango,
    Strawberry,
    None
}