using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private GameObject _inventoryUI;

    private void Start()
    {
        CharacterManager.Instance.Player.Controller.InventoryOriginal += InventoryToggle;
        CharacterManager.Instance.Player.GetItem += AddItem;
    }

    private void InventoryToggle()
    {
        _inventoryUI.SetActive(!_inventoryUI.activeInHierarchy);
    }

    private void AddItem()
    {
        ItemData Data = CharacterManager.Instance.Player.itemData;

        // CharacterManager.Instance.Player.InventoryList + Data;
        for (int i = 0; i < CharacterManager.Instance.Player.InventoryArray.Length; i++)
        {
            if (CharacterManager.Instance.Player.InventoryArray[i] == null)
            {
                CharacterManager.Instance.Player.InventoryArray[i] = Data;
                break;
            }
        }
    }
}