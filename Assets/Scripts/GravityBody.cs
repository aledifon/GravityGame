using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{

    [SerializeField] protected GravityAttractor attractor = null;
    [SerializeField] protected int grounded;
    
    protected Rigidbody rb;

    #region Unity API
    void Awake()
    {
        rb = GetComponent<Rigidbody>();   
        rb.useGravity = false;              // Disable the Unity gravity
        rb.freezeRotation = true;           // Freeze the rotation by physics
                                            // as we'll rotate the GO manually
    }
    
    void FixedUpdate()
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
        if(collision.collider.CompareTag("Planet"))
            grounded++;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Planet"))
            grounded--;
    }
    #endregion
}
