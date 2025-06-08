using UnityEngine;

public enum ItemType
{
    Money,
    Equipable,
    Consumable,
    Resource,
    Material,
    Etc
}

public enum ConsumableType
{
    Health,
    Mana
}
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stack")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}