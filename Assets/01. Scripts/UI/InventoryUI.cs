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
		
		inventoryWindow.SetActive(false);
		slots = new ItemSlot[slotPanel.childCount];

		for (int i = 0; i < slots.Length; i++)
		{
			slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
			slots[i].index = i;
			slots[i].inventory = this;
		}
	}
	
	void Update()
	{
		
	}

	void ClearSelectedSlotInfo()
	{
		selectedItemName.text = string.Empty;
		selectedItemDesc.text = string.Empty;
	}
}