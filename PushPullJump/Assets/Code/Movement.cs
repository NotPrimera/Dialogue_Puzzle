using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private PullableObject pullableObject;
    private bool isPulling = false;
    private float lastToggleTime = 0f;
    private float toggleCooldown = 0.2f; 

    public Transform groundCheck; 
    public LayerMask groundLayer; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isPulling)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        float move = Input.GetAxis("Horizontal");
    
        if (!isPulling)
        {
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(move * moveSpeed * 0.8f, rb.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.E) && pullableObject != null && Time.time - lastToggleTime > toggleCooldown)
        {
            isPulling = !isPulling;
            pullableObject.TogglePull(isPulling, rb);
            lastToggleTime = Time.time; 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pullable"))
        {
            pullableObject = other.GetComponent<PullableObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pullable") && !isPulling)
        {
            pullableObject = null;
        }
    }
}
