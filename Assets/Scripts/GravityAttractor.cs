using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    [SerializeField] private float gravity;

    public void Attract(GravityBody body, Rigidbody bodyRB)
    {
        // Get the Transform & Rb Refs. of the attracted body
        Transform trans = body.transform;     
        Rigidbody rb = bodyRB;

        Vector3 gravityUp = trans.position - transform.position;
        gravityUp.Normalize();                                      // Normalize the vector just to get its direction

        // Attraction force
        rb.AddForce(gravityUp * gravity * rb.mass);


        //If the attracted object has their rotations frozen
        if(rb.freezeRotation == true)
        {
            // Create a rotation which goes from the Y-Axis of the character towards gravityUp
            Quaternion rotation = Quaternion.FromToRotation(trans.up, gravityUp);

            // Applies the calculated rotation to the current one of the attracted object
            rotation = rotation * trans.rotation;

            // Linear Interp. of the the current rotation to the calculated one.
            trans.rotation = Quaternion.Slerp(trans.rotation, rotation, 0.1f);
        }
    }
}
