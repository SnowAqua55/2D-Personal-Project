using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Moving")]
    public float jumpForce;
    public float baseMoveSpeed;
    public float bonusMoveSpeed;
    private float _curMoveSpeed;
    public float jumpRayDistance;
    public LayerMask groundLayerMask;

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
    }

    private void Start()
    {

    }

    private void Update()
    {
        Move();
        _curMoveSpeed = baseMoveSpeed + bonusMoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && GameManager.Instance.Player.movePossible)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
            GameManager.Instance.Player.movePossible = false;
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
}
