using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float runSpeed = 400f;
    private float horizontalMove = 0f;
    private bool jump = false;
    public bool startCamera = false;
    public bool jumping = false;
    [SerializeField] private FloatingJoystick floatingJoystick;

    public Rigidbody2D rb;
    private bool isLanding;

    private void Update()
    {
        if (rb.velocity.y < 0)  //ускорение по У меньше нуля
        {
            isLanding = true;
        }
        else isLanding = false;

        animator.SetBool("IsLanding", isLanding);

        if (floatingJoystick.Horizontal >= 0.2)
        {
            //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            horizontalMove = runSpeed;
        }else if (floatingJoystick.Horizontal <= -0.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

//        if (Input.GetButtonDown("Jump"))
//        {
//            jump = true;
//            animator.SetBool("IsJumping", true);
//        }
//        
        
        if (floatingJoystick.Vertical >= 0.5f)
        {
            Jumping();
        }
    }

    public void onLanding()
    {
        jumping = false;
        animator.SetBool("IsJumping", false);
        
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
       
    }

    public void Jumping()
    {
        jump = true;
        animator.SetBool("IsJumping", true);
        jumping = true;
        startCamera = true;
      
    }
}
