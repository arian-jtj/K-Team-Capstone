using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour, IDataPersistance
{
    [Header("PlayerData")]
    public int clearedLevel;
    public string currentLevel;

    [Header("Player Settings")]
    public float speed;
    public float runSpeed;
    public float acceleration;
    public float deceleration;
    public float jumpingPower;
    public int extraJumpValue;
    private int extraJump;
    private bool isFacingRight = true;
    private float horizontal;
    private float currentSpeed;
    private Rigidbody2D rb;

    [Header("Components")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteTransform;
    [SerializeField] private Hair hair;
    [SerializeField] private Animator animator;
    public PlayerVectorValue spawnPosition;
    private Vector2 savePosition;
    //spawn point position, used for when changing scenes or respawning

    [Header("Portal")]
    public bool isInPortal = false;

    [Header("Ground Check")]
    public float checkRadius;

    [Header("Audio Controller")]
    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip runningSound;
    [SerializeField] private AudioClip jumpSound;
    private bool isJumpSound;


    private void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0f;
        transform.position = spawnPosition.changingValue;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        UpdateAnimation();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            savePosition = new Vector2(transform.position.x, transform.position.y);
            Debug.Log(clearedLevel);
            Debug.Log(currentLevel);
        }

        // Jump
        if (isGrounded())
        {
            extraJump = extraJumpValue;

            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (isJumpSound)
        //        return;
        //    isJumpSound = true;
        //    SoundManager.instance.PlaySound(jumpSound);
        //}

        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            extraJump--;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if (Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
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
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float targetSpeed = horizontal * (isRunning ? runSpeed : speed);

        if (Mathf.Abs(currentSpeed - targetSpeed) > 0.01f)
        {
            if (currentSpeed < targetSpeed)
            {
                currentSpeed += acceleration * Time.fixedDeltaTime;
                if (currentSpeed > targetSpeed)
                    currentSpeed = targetSpeed;

            }
            else if (currentSpeed > targetSpeed)
            {
                currentSpeed -= deceleration * Time.fixedDeltaTime;
                if (currentSpeed < targetSpeed)
                    currentSpeed = targetSpeed;
            }
        }
        else
        {
            currentSpeed = targetSpeed;

            if (horizontal == 0)
            {
                if (isGrounded())
                {
                SoundManager.instance.StopSound();
                }
                else
                {
                    SoundManager.instance.PlaySound(jumpSound);
                }
            }
            else
            {
                if (isGrounded())
                {

                SoundManager.instance.PlaySound(isRunning ?runningSound : walkingSound);
                }
                else
                {
                    SoundManager.instance.PlaySound(jumpSound);
                }

            }
        }

        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        bool grounded = isGrounded();
        animator.SetBool("IsGrounded", grounded);

        if (grounded)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            isJumpSound = false;
        }
        else
        {
            animator.SetBool("IsFalling", rb.velocity.y < 0f && !grounded);
        }
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
        }
    }

    private void UpdateAnimation()
    {
        float absoluteSpeed = Mathf.Abs(currentSpeed);

        animator.SetFloat("Speed", absoluteSpeed);

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && absoluteSpeed > 0.1f;
        animator.SetBool("IsRunning", isRunning);
    }

    public void LoadData(GameData data)
    {
        this.savePosition = data.playerCurrentPosition;
        this.clearedLevel = data.clearedLevel;
        this.currentLevel = data.currentLevel;
    }

    public void SaveData(ref GameData data)
    {
        data.playerCurrentPosition = this.transform.position;
        data.clearedLevel = this.clearedLevel;
        data.currentLevel = this.currentLevel;
    }

    
}