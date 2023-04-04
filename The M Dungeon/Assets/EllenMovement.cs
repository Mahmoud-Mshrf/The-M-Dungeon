using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool croush = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Croush"))
        {
            croush = true;
            animator.SetBool("IsCroushing", true);
        }
        else if (Input.GetButtonUp("Croush"))
        {
            croush = false;
        }
    }
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCroushing(bool isCroushing)
    {
        animator.SetBool("IsCroushing", isCroushing);
    }
    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.deltaTime, croush, jump);
        jump = false;
    }
}
