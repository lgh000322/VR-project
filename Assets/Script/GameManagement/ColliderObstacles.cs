using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObstacles : MonoBehaviour
{
    public float bounceForce = 50.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌이 발생한 물체의 Rigidbody2D 컴포넌트 가져오기
        Rigidbody2D collidedRb = collision.gameObject.GetComponent<Rigidbody2D>();

        // 충돌이 발생한 물체가 Rigidbody2D를 가지고 있는지 확인
        if (collidedRb != null)
        {
            // 공의 방향으로 튕기는 힘 계산
            Vector2 direction = (collidedRb.position - collision.contacts[0].point).normalized;
            Vector2 bounceDirection = direction * bounceForce;

            // 튕기는 힘을 공에 가하기
            collidedRb.velocity = Vector2.zero;
            collidedRb.angularVelocity = 0f;
            collidedRb.AddForce(bounceDirection, ForceMode2D.Impulse);

            Debug.Log("충돌");
        }
    }
}
