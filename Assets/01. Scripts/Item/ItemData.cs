using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource,
    Material,
    Etc
}
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
}