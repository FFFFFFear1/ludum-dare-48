using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapper : MonoBehaviour
{
    private Camera mainCamera;
    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;

    public bool canGrappo = false;
 
    
    public static Grapper instance;
    
    void Start()
    {
        instance = this;
        mainCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!canGrappo) return;
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            distanceJoint.connectedAnchor = mousePos;
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }
        if (distanceJoint.enabled) 
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}
