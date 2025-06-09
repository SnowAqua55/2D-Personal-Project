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
		_controller = CharacterManager.Instance.Player.Controller;
		_condition = CharacterManager.Instance.Player.Condition;

		_controller.InventoryOriginal += InventoryToggle;
		_controller.InventoryOriginal += CursorToggle;
		_controller.InventoryOriginal += MovePossibleToggle;
		
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
			CharacterManager.Instance.Player.movePossible = false;
		else
			CharacterManager.Instance.Player.movePossible = true;
	}

	void GetItem()
	{

	}
}