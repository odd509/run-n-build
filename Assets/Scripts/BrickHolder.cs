using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHolder : MonoBehaviour
{
    public GameObject jointBrick = null;
    public float brickOffset = .5f;
    public float lerpSpeed = 2f;

    public void addJoint(GameObject brick)
    {
        if (jointBrick == null)
        {
            jointBrick = brick;
            
            /*
            brick.transform.position = Vector3.Lerp(brick.transform.position, 
                new Vector3(transform.position.x, transform.position.y + brickOffset, transform.position.z), 
                lerpSpeed * Time.deltaTime);
            */

            brick.transform.position = transform.position;
            
            brick.AddComponent<CharacterJoint>();
            brick.GetComponent<CharacterJoint>().connectedBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            GameObject tempBrick = jointBrick;
            while (tempBrick.GetComponent<BrickBehaviour>().jointBrick != null)
            {
                tempBrick = tempBrick.GetComponent<BrickBehaviour>().jointBrick;
            }

            /*
            brick.transform.position = Vector3.Lerp(brick.transform.position, 
                new Vector3(tempBrick.transform.position.x, tempBrick.transform.position.y + brickOffset, tempBrick.transform.position.z), 
                lerpSpeed * Time.deltaTime);
            */
            
            brick.transform.position = tempBrick.transform.position + new Vector3(0, brickOffset, 0);
            tempBrick.GetComponent<BrickBehaviour>().jointBrick = brick;
            brick.AddComponent<CharacterJoint>();
            brick.GetComponent<CharacterJoint>().connectedBody = tempBrick.GetComponent<Rigidbody>();

        }
    }

    private void OnJointBreak(float breakForce)
    {
        jointBrick = null;
    }
}
