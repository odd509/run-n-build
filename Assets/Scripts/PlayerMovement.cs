using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 3f;
    public float sideSpeed = 2f;
    public float runBorder = 1.5f;
    
    
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0,runSpeed * Time.deltaTime);
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));

            touchPosition.z = transform.position.z;
            touchPosition.y = transform.position.y;

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * sideSpeed);
            }
            
            
            
            Debug.Log(touchPosition);
            Debug.Log(touch.position);


        }
        
        
        
        if (transform.position.x > runBorder)
        {
            transform.position = new Vector3(runBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -runBorder)
        {
            transform.position = new Vector3(-runBorder, transform.position.y, transform.position.z);
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position + new Vector3(runBorder, 0, 0));
        Gizmos.DrawLine(position, position + new Vector3(-runBorder, 0, 0));

    }
}