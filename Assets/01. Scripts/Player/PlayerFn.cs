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

    private void FixedUpdate()
    {
        Collider2D[] pullingItemsArray = Physics2D.OverlapCircleAll(_playerTransform.position, pullRadius, itemLayer);

        if (pullingItemsArray != null)
        {
            for (int i = 0; i < pullingItemsArray.Length; i++)
            {
                Collider2D pulledItem = pullingItemsArray[i];
                Rigidbody2D itemRb = pulledItem.GetComponent<Rigidbody2D>();
                Vector2 pullingToPlayer = (Vector2)_playerTransform.position - (Vector2)itemRb.transform.position;
            }
        }
    }

    // 플레이어와 아이템이 충돌했을 때
    
    // 범위 안에 들어온 아이템이 인벤토리에 있는지 체크
    
    // 가지고 있는 아이템이면서 스택이 가능하면 끌어오기
    
    // 
    
    private void InventoryCheck()
    {
        // 반복문으로 인벤토리 슬롯을 돌아서 빈 슬롯이 있는지 체크
        // 아이템 정보를 확인 후 중복 가능한 아이템일 경우 슬롯 중에 해당 아이템이 있으면
        // 혹은 아이템이 없지만 빈 슬롯이 있다면

        // 아이템을 끌어당김

        // 플레이어가 아이템의 콜라이더와 부딪혔다면
        // 미리 검사한 인벤토리 정보에 해당 아이템을 추가

        // 아이템 획득 후 드롭되어 있는 아이템 오브젝트는 Destroy
    }
}