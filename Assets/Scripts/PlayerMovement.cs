using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GravityBody
{
    //[SerializeField] float speed;
    //[SerializeField] float turnSpeed;

    ////[SerializeField] float angleInc;
    //float desiredYRotation;

    //Rigidbody rb;

    //float h, v;

    //void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    
    //void Update()
    //{        
    //    Vector3 posPlayer = new Vector3(rb.position.x,
    //                                    rb.position.y,
    //                                    Input.GetAxis("Vertical") * v * speed * Time.deltaTime);
    //    rb.MovePosition(Vector3.Lerp(rb.position,posPlayer,0.1f));

    //    // Create a rotation around the Y-Axis of the Player
    //    desiredYRotation = desiredYRotation + 
    //                        Input.GetAxis("Horizontal") * h * turnSpeed * Time.deltaTime;



    //    rb.MoveRotation(Quaternion.Slerp(rb.rotation,));

    //}

}
