using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 3f;
    public float sideSpeed = 2f;

    private float horizontalDirection; 
    
    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        }
        
    }

    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }
}
