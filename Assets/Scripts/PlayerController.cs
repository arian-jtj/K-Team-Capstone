using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    public bool isInPortal = false; //check if the player is inside the portal

    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (isGrounded == true) {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}