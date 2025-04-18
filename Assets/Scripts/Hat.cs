using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : GravityBody, IActionable
{
    [SerializeField] Transform point;   // Point is a Player's child

    public void Action()
    {
        attractor = null;
        transform.SetParent(point);
        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;
        transform.localPosition = Vector3.zero;
    }
}
