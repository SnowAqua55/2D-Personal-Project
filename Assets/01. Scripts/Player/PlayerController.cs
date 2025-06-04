using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Moving")]
    public float jumpForce;
    public float baseMoveSpeed;
    public float curMoveSpeed;
    public float jumpRayDistance;
    public LayerMask groundLayerMask;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput;
    private Vector3 _direction;

    private bool _isGround;
    private int _isMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _isMove = Animator.StringToHash("isMove");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveInput = context.ReadValue<Vector2>();
            _animator.SetBool(_isMove, true);
        }
        else if (context.canceled)
        {
            _moveInput = Vector2.zero;
            _animator.SetBool(_isMove, false);
        }
    }

    private void Move()
    {
        _direction = transform.forward * 
    }
}
