using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private FixedJoint2D joint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<FixedJoint2D>();
        joint.enabled = false; 
    }

    public void TogglePull(bool isPulling, Rigidbody2D playerRb)
    {
        if (isPulling)
        {
            joint.enabled = true;
            joint.connectedBody = playerRb; 
        }
        else
        {
            joint.connectedBody = null; 
            joint.enabled = false; 
            rb.velocity = Vector2.zero; 
            rb.angularVelocity = 0f; 
        }
    }

}
