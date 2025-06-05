using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
}