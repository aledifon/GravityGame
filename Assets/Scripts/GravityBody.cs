using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{

    [SerializeField] protected GravityAttractor attractor = null;
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected int jumpCounter;
    
    protected Rigidbody rb;

    #region Unity API
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();   
        rb.useGravity = false;              // Disable the Unity gravity
        rb.freezeRotation = true;           // Freeze the rotation by physics
                                            // as we'll rotate the GO manually
    }
    
    protected virtual void FixedUpdate()
    {
        if(attractor != null)
        {
            attractor.Attract(this,rb);
        } 
    }
    #endregion

    #region Detect Ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Planet"))
        {
            isGrounded = true;
            jumpCounter = 0;
        }
            
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Planet"))
        {
            isGrounded = false;            
        }            
    }
    #endregion
}
