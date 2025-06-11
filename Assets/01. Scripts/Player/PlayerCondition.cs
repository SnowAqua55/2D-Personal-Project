using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
	private void Awake()
	{
		CharacterManager.Instance.Player.Condition = this;
	}

	void Start()
	{
		
	}
	
	void Update()
	{
		
	}
}