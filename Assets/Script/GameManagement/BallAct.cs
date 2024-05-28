using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAct : MonoBehaviour
{
    public float raycastDistance = 60.0f;
    public string[] targetTags = { "RotatingObject", "RotatingObstacles" };
    public float bounceForce = 60.0f;

    private Vector2 previousPosition;
    private Vector2 preCollisionPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        previousPosition = transform.position;
        preCollisionPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        // 충돌 감지 모드를 연속으로 설정
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;

        if (IsAboutToCollide(currentPosition, previousPosition, raycastDistance, targetTags))
        {
            Vector2 bounceDirection = (currentPosition - previousPosition).normalized * bounceForce;
            rb.velocity = Vector2.zero;

            transform.position = preCollisionPosition;
            rb.AddForce(bounceDirection, ForceMode2D.Impulse);
        }
        else
        {
            preCollisionPosition = previousPosition;
            previousPosition = currentPosition;
        }
    }

    private bool IsAboutToCollide(Vector2 currentPosition, Vector2 previousPosition, float raycastDistance, string[] targetTags)
    {
        Vector2 direction = (currentPosition - previousPosition).normalized;
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction, raycastDistance);
        if (hit.collider != null)
        {
            foreach (string tag in targetTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Array.Exists(targetTags, tag => collision.collider.CompareTag(tag)))
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 ballCenter = collision.collider.bounds.center;
            Vector2 bounceDirection = (ballCenter - collisionPoint).normalized;
            rb.velocity = bounceDirection * bounceForce;
        }
    }
}
