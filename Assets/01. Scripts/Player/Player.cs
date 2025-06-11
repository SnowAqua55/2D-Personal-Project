using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public PlayerCondition Condition;

    public ItemData itemData;
    public Action GetItem;
    public List<ItemData> InventoryList = new List<ItemData>();

    public ItemData[] InventoryArray = new ItemData[21];

    public bool movePossible;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}