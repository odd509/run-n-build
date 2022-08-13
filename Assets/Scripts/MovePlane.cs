using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    private float runSpeed;

    public PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Awake()
    {
        runSpeed = playerMovementScript.runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0,runSpeed * Time.deltaTime);
    }
}
