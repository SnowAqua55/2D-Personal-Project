using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public PlayerCondition Condition;
    public InventoryUI InvenUI;

    public ItemData itemData;
    public Action GetItem;
    // public List<ItemData> InventoryList = new List<ItemData>();

    public ItemData[] inventoryArray = new ItemData[2];

    public bool movePossible;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}