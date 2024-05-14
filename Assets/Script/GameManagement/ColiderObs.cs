using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderObs : MonoBehaviour
{
    public float bounceForce = 50.0f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        Vector3 bounceDirection = Vector3.up * bounceForce;
        playerRb.AddForce(bounceDirection, ForceMode2D.Impulse);

        Debug.Log("충돌");
    }
}
