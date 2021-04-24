using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanGrappo : MonoBehaviour
{
    private void OnMouseDown()
    {
        Grapper.instance.canGrappo = true;
    }

    private void OnMouseUp()
    {
        Grapper.instance.canGrappo = false;
    }
}
