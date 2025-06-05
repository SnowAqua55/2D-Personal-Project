using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Moving")]
    public float jumpForce;
    public float baseMoveSpeed;
    private float _curMoveSpeed;
    public float jumpRayDistance;
    public LayerMask groundLayerMask;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;
    private Vector2 _moveDirection;

    private bool _isGround;
    private int _isMove;
    private int _animDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _isMove = Animator.StringToHash("isMove");
        _animDirection = Animator.StringToHash("Direction");
        // front:0 (down)
        // back:1 (up)
        // left:2
        // right:3

        _curMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveInput = context.ReadValue<Vector2>();
            // _animator.SetBool(_isMove, true);
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
            // _animator.SetBool(_isMove, false);
        }
    }

    private void Move()
    {
        _moveDirection = transform.forward * _moveInput.y + transform.right * _moveInput.x;
        _moveDirection *= _curMoveSpeed;
    }

    private void AnimDirection()
    {
        
    }
}
