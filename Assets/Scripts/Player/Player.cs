using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed;
    public float jumpingPower;
    public int extraJumpValue;
    private int extraJump;
    private bool isFacingRight = true;
    private float horizontal;
    private Rigidbody2D rb;

    [Header("Components")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteTransform;
    [SerializeField] private Hair hair;

    [Header("Portal")]
    public bool isInPortal = false;

    [Header("Ground Check")]
    public float checkRadius;

    private void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Jump
        if (isGrounded())
        {
            extraJump = extraJumpValue;
        }

        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            extraJump--;
        }
        else if (Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Reduce Jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // Horizontal Movement
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        // Ground Checker
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void Flip()
    {
        // Flip Player
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            spriteTransform.flipX = !isFacingRight;
            if (isFacingRight)
            {
                hair.targetDir.localRotation = Quaternion.Euler(0, 0, -180);
                hair.targetDir.localPosition = new Vector3(-0.5f, 0.5f, 0f);
            }
            else
            {
                hair.targetDir.localRotation = Quaternion.Euler(0, 0, 0);
                hair.targetDir.localPosition = new Vector3(0.5f, 0.5f, 0f);
            }
        }
    }
}