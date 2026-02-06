using UnityEngine;

public class Scr_Player : MonoBehaviour
{
    public float horizontal;
    float speed = 8f;
    float jumpingPower = 7f;
    bool isFacingRight = true;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
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


