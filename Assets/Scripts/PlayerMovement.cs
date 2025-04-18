using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : GravityBody
{
    [Header ("Movement vars.")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float force;
    [SerializeField] private float jumpSpeed;
    //[SerializeField] private float turnSpeed;
    
    private float horizontal;
    private float vertical;

    // Boolean flags
    private bool canJump;

    // GO components
    private Animator anim;
    //private Rigidbody rb;

    //[SerializeField] float angleInc;
    float desiredYRotation;

    #region Unity API
    protected override void Awake()
    {       
        base.Awake();

        //rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {        
        InputPlayer();        
        JumpInput();
        RotationVectors();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Movement();
        Jump();

        //Vector3 posPlayer = new Vector3(rb.position.x,
        //                                rb.position.y,
        //                                vertical * maxSpeed * Time.deltaTime);

        //rb.MovePosition(Vector3.Lerp(rb.position, posPlayer, 0.1f));

        // Create a rotation around the Y-Axis of the Player
        //desiredYRotation = desiredYRotation +
        //                    horizontal * turnSpeed * Time.deltaTime;
        //rb.MoveRotation(Quaternion.Slerp(rb.rotation,));

        //rb.AddForce(posPlayer);
    }
    #endregion

    #region Private Methods
    private void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }    
    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 2)
        {
            canJump = true;             
        }
    }
    private void Movement()
    {        
        if(rb.velocity.magnitude <= maxSpeed)
        {
            // Forward movement
            // tranform.rotation * Vector3.forward = transform.forward
            // This means Quaternion * Vector3 = Applied Rotation
            rb.AddForce(transform.rotation * Vector3.forward * vertical * force);

            // Lateral Movement
            rb.AddForce(transform.rotation * Vector3.right * horizontal * force);
        }
    }
    private void Jump() 
    {
        if (canJump)
        {
            // Reset Jump Enable Flag & Increase Jump Counter
            canJump = false;
            jumpCounter++;
            rb.velocity += (rb.transform.up * jumpSpeed);
        }
    }

    private void RotationVectors()
    {
        Quaternion rot = Quaternion.Euler(0,25,0);
        Vector3 d = rot * transform.forward;

        //// Draw the d vector
        //Debug.DrawLine(transform.position, transform.position + (d*10), Color.red);
        //// Draw the foward vector
        //Debug.DrawLine(transform.position, transform.position + (transform.forward * 10), Color.blue);
    }
    #endregion
}






//private void FixedUpdate()
//{
//    //Vector3 posPlayer = new Vector3(rb.position.x,
//    //                                rb.position.y,
//    //                                vertical * maxSpeed * Time.deltaTime);

//    //rb.MovePosition(Vector3.Lerp(rb.position, posPlayer, 0.1f));

//    // Create a rotation around the Y-Axis of the Player
//    //desiredYRotation = desiredYRotation +
//    //                    horizontal * turnSpeed * Time.deltaTime;
//    //rb.MoveRotation(Quaternion.Slerp(rb.rotation,));

//    //rb.AddForce(posPlayer);
//}
