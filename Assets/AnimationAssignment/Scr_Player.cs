using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Scr_Player : MonoBehaviour
{
    public float horizontal;
    float speed = 8f;
    float jumpingPower = 7f;
    bool isFacingRight = true;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && horizontal == 1f)
            {
                animator.SetFloat("X Speed", 1);
            }
        else if (IsGrounded() && horizontal == -1f)
            {
                animator.SetFloat("X Speed", 1f);
            }

        if(Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            animator.SetFloat("X Speed", 0);
        }
        if (Keyboard.current.rightArrowKey.wasReleasedThisFrame)
        {
            animator.SetFloat("X Speed", 0);
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            animator.SetFloat("Y Speed", 1);
        }

        if(Keyboard.current.spaceKey.isPressed == false)
        {
            animator.SetFloat("Y Speed", 0);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            animator.SetFloat("Y Speed", 1);
        }


        if (Keyboard.current.downArrowKey.isPressed && IsGrounded())
        {
            animator.SetFloat("Taunt", 1);
            speed = 0;
        }

        if (Keyboard.current.downArrowKey.wasReleasedThisFrame && IsGrounded())
        {
            animator.SetFloat("Taunt", 0);
            speed = 8;
        }            
            
        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        if (isFacingRight == true && horizontal == -1f)
        {
            isFacingRight = false;
            Vector3 localeScale = transform.localScale;
            localeScale.x = -localeScale.x;
            transform.localScale = localeScale;
        }

        if(isFacingRight == false && horizontal == 1f)
        {
            isFacingRight = true;
            Vector3 localeScale = transform.localScale;
            localeScale.x = -localeScale.x;
            transform.localScale = localeScale;
        }
    }

}


