using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller { get; private set; }
    public PlayerCondition Condition { get; private set; }

    public bool movePossible;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        Controller = GetComponent<PlayerController>();
    }
}