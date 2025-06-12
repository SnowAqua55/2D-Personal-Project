using System;
using UnityEngine;

public class PlayerFn : MonoBehaviour
{
    [Header("Pull Item")]
    public float pullRadius;
    public float pullForce;
    public LayerMask itemLayer;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = transform;
    }

    // private void FixedUpdate()
    // {
    //     Collider2D[] pullingItemsArray = Physics2D.OverlapCircleAll(_playerTransform.position, pullRadius, itemLayer);
    //
    //     if (pullingItemsArray != null)
    //     {
    //         for (int i = 0; i < pullingItemsArray.Length; i++)
    //         {
    //             Collider2D pulledItem = pullingItemsArray[i];
    //             Rigidbody2D itemRb = pulledItem.GetComponent<Rigidbody2D>();
    //             Vector2 pullingToPlayer = (Vector2)_playerTransform.position - (Vector2)itemRb.transform.position;
    //         }
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            ItemObject obj = other.gameObject.GetComponent<ItemObject>();
            ItemData Data = obj.data;

            bool AddedItem = CharacterManager.Instance.Player.InvenUI.AddItem(obj, Data);
            if (AddedItem)
            {
                Destroy(other.gameObject);
            }
            else
            {
                return;
            }
        }
    }
}