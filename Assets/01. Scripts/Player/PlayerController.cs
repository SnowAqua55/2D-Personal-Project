using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Moving")]
    public float baseMoveSpeed;
    public float bonusMoveSpeed;
    private float _curMoveSpeed;

    public Action InventoryOriginal;
    public Action Inventory;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;
    private Vector2 _moveDirection;
    private float _lastDirection;
    private SpriteRenderer _sprite;

    private bool _isGround;
    private int _isMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        CharacterManager.Instance.Player.Controller = this;
        Action:Inventory = InventoryOriginal;
    }

    private void Start()
    {
        CharacterManager.Instance.Player.movePossible = true;
        
    }

    private void FixedUpdate()
    {
        Move();
        _curMoveSpeed = baseMoveSpeed + bonusMoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && CharacterManager.Instance.Player.movePossible)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
        }
    }

    private void Move()
    {
        // _moveDirection = transform.up * _moveInput.y + transform.right * _moveInput.x;
        // _moveDirection *= _curMoveSpeed;
        //
        // _rigidbody.velocity = _moveDirection;

        _rigidbody.velocity = _moveInput * _curMoveSpeed;
        if (_moveInput.x != 0f)
        {
            _lastDirection = Math.Sign(_moveInput.x);
        }

        bool isLeft = _lastDirection < 0f;
        _sprite.flipX = isLeft;
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Inventory?.Invoke();
            _moveInput = Vector2.zero;
        }
    }
}
