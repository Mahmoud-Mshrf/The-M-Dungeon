using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float HorizontalMove;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    PolygonCollider2D polygonCollider;
    public float MoveSpeed = 7f;
    public float JumpPower = 14f;
    public LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }
    MovementState state1 = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("Hello world");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        //animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        rb.velocity = new Vector2(HorizontalMove * MoveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && Isgrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }
        polygonCollider = GetComponent<PolygonCollider2D>();
        UpdateAinmation();
    }
    private void UpdateAinmation()
    {
        MovementState state;
        if (HorizontalMove > 0f)
        {
            //animator.SetBool("Running", true);
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (HorizontalMove < 0f)
        {

            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("state", (int)state);
    }
    private bool Isgrounded()
    {
        return Physics2D.BoxCast(polygonCollider.bounds.center, polygonCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
