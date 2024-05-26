using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAct : MonoBehaviour
{
    public float raycastDistance = 30.0f;
    public string[] targetTags = { "RotatingObject", "RotatingObstacles" };
    public float bounceForce = 60.0f;

    private Vector2 previousPosition;
    private Vector2 preCollisionPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        // 시작 시점의 위치 기억
        previousPosition = transform.position;
        preCollisionPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 현재 위치 기억
        Vector2 currentPosition = transform.position;

        // 충돌 예측 및 위치 조정
        if (IsAboutToCollide(currentPosition, previousPosition, raycastDistance, targetTags))
        {
            Debug.Log("충돌 예측.");
            // 충돌 예측 시 반발력 적용
            Vector2 bounceDirection = (currentPosition - previousPosition).normalized * bounceForce;
            rb.velocity = Vector2.zero;

            // 이전 위치로 물체 이동
            transform.position = preCollisionPosition;
            rb.AddForce(bounceDirection, ForceMode2D.Impulse);
        }
        else
        {
            // 현재 위치를 이전 위치로 업데이트
            preCollisionPosition = previousPosition;
            previousPosition = currentPosition;
        }
    }

    private bool IsAboutToCollide(Vector2 currentPosition, Vector2 previousPosition, float raycastDistance, string[] targetTags)
    {
        // 특정 거리만큼 아래로 레이캐스트
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, Vector2.down, raycastDistance);
        if (hit.collider != null)
        {
            Debug.Log("hit.collider.name= " + hit.collider.name);
            // 충돌한 오브젝트의 태그가 targetTags 배열에 포함되어 있는지 확인
            foreach (string tag in targetTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    // 충돌한 콜라이더의 y좌표와 현재 공의 y좌표 비교
                    if (currentPosition.y < hit.collider.bounds.max.y)
                    {
                        Debug.Log("레이캐스트 실행 " + hit.collider.name);
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
