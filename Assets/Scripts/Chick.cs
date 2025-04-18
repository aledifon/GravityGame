using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : GravityBody, IActionable
{
    [SerializeField] Vector3 newScale;
    public void Action()
    {
        attractor = null; // Doing this I'm removing the Planet gravity attraction
        transform.localScale = newScale;
    }
}
