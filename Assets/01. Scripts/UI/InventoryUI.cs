using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public ItemSlot[] slots;
	public GameObject inventoryWindow;
	public Transform slotPanel;

	[Header("Select Item")]
	public TextMeshProUGUI selectedItemName;
	public TextMeshProUGUI selectedItemDesc;

	private PlayerController _controller;
	private PlayerCondition _condition;
	
	void Start()
	{
		_controller = GameManager.Instance.Player.Controller;
		_condition = GameManager.Instance.Player.Condition;

		_controller.Inventory += InventoryToggle;
		_controller.Inventory += CursorToggle;
		_controller.Inventory += MovePossibleToggle;
		
		inventoryWindow.SetActive(false);
		slots = new ItemSlot[slotPanel.childCount];

		for (int i = 0; i < slots.Length; i++)
		{
			slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
			slots[i].index = i;
			slots[i].inventory = this;
		}
		
		ClearSelectedSlotInfo();
	}

	void ClearSelectedSlotInfo()
	{
		selectedItemName.text = string.Empty;
		selectedItemDesc.text = string.Empty;
	}

	public void InventoryToggle()
	{
		inventoryWindow.SetActive(!inventoryWindow.activeInHierarchy);
	}

	public void CursorToggle()
	{
		if (inventoryWindow.activeInHierarchy)
			Cursor.lockState = CursorLockMode.None;
		else
			Cursor.lockState = CursorLockMode.Locked;
	}

	public void MovePossibleToggle()
	{
		if (inventoryWindow.activeInHierarchy)
			GameManager.Instance.Player.movePossible = false;
		else
			GameManager.Instance.Player.movePossible = true;
	}
}