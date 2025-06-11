using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject _inventoryUI;

    private void Awake()
    {
        CharacterManager.Instance.Player.InvenUI = this;
    }

    private void Start()
    {
        CharacterManager.Instance.Player.Controller.InventoryOriginal += InventoryToggle;
        _inventoryUI.SetActive(false);
    }

    private void InventoryToggle()
    {
        _inventoryUI.SetActive(!_inventoryUI.activeInHierarchy);
    }

    public void AddItem(ItemObject obj, ItemData Data)
    {
        // CharacterManager.Instance.Player.InventoryList + Data;
        for (int i = 0; i < CharacterManager.Instance.Player.inventoryArray.Length; i++)
        {
            if (CharacterManager.Instance.Player.inventoryArray[i] == null)
            {
                CharacterManager.Instance.Player.inventoryArray[i] = Data;
                Destroy(obj.gameObject);
                return;
            }
            else
            {
                Debug.Log("인벤토리가 가득 찼습니다");
                return;
            }
        }
    }

    public void InventoryCheck()
    {
        Debug.Log($"{CharacterManager.Instance.Player.inventoryArray[0]}\n{CharacterManager.Instance.Player.inventoryArray[1]}");
    }
}