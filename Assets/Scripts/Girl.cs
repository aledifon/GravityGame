using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : GravityBody, IActionable
{
    [SerializeField] Material newMaterial;
    [SerializeField] Renderer rend;

    public void Action()
    {
        rend.material = newMaterial;
    }
}
