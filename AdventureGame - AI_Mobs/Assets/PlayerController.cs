using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isClimbing;
    private float inputVertical;
//    private float jumpInput;

    private Rigidbody2D rb;



    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float distance;
    public LayerMask whatIsLadder;

    void Start(){
      rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate(){

      RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

      if(hitInfo.collider != null){
        if(Input.GetKey("w")){
          isClimbing = true;

        }
      } else {
        isClimbing = false;
        
      }


      if(isClimbing == true){
        inputVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
        rb.gravityScale = 0;
      } else {
        rb.gravityScale = 5;
      }


// Start of Movement
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
  //    Debug.Log(isGrounded);
      moveInput = Input.GetAxis("Horizontal");
//      jumpInput = Input.GetAxis("Jump");
//      Debug.Log(jumpInput);

      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



      if(facingRight == false  && moveInput > 0){
        flip();
      }else if(facingRight == true && moveInput < 0){
        flip();
      }
      if(isGrounded == false){
        animator.SetBool("IsJumping",true);
      }else if(isGrounded == true){
        animator.SetBool("IsJumping",false);
      }

    }

    void Update(){


      if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
    //    Debug.Log("test");
        rb.velocity = Vector2.up * jumpForce;

      }
    }

    void flip(){
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
    }


}
