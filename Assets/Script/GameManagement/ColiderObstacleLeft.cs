using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderObstacleLeft : MonoBehaviour
{
    public float bounceForce = 150.0f;
    public GameObject otherObject; // 다른 오브젝트의 참조

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (otherObject.GetComponent<RotateLeftBar>().isRotating)
        {
            // 충돌이 발생한 물체의 Rigidbody2D 컴포넌트 가져오기
            Rigidbody2D collidedRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // 충돌이 발생한 물체가 Rigidbody2D를 가지고 있는지 확인
            if (collidedRb != null)
            {
                // 충돌 지점의 x좌표를 가져옵니다.
                float collisionX = collision.contacts[0].point.x;

                // 물체의 최대 y좌표를 가져옵니다.
                float maxY = GetComponent<Collider2D>().bounds.max.y;

                // 최대 y좌표에 공을 고정시킵니다.
                Vector2 collisionPoint = new Vector2(collisionX, maxY);

                // 충돌 지점에 공을 고정시킵니다.
                collidedRb.position = collisionPoint;

                // 충돌 방향과 힘 계산
                Vector2 direction = (collidedRb.position - collision.contacts[0].point).normalized;
                Vector2 bounceDirection = direction * bounceForce;

                // 튕기는 힘을 공에 가하기
                collidedRb.velocity = Vector2.zero;
                collidedRb.angularVelocity = 0f;
                collidedRb.AddForce(bounceDirection, ForceMode2D.Impulse);
            }
        }

    }
}
