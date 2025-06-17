using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushForce = 5f;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            float direction = collision.transform.position.x > transform.position.x ? -1 : 1;
            rb.velocity = new Vector2(direction * pushForce, rb.velocity.y);
        }
    }
}
