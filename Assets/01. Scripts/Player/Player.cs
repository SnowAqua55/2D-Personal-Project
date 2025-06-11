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

    public ItemData[] inventoryArray;

    public bool movePossible;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        inventoryArray = new ItemData[2];
    }

    private void Update()
    {
        CharacterManager.Instance.Player.InvenUI.InventoryCheck();
    }
}