using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject materialSpawner;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.GetComponent<Collectable>().pairItem == null)
        {
            materialSpawner.GetComponent<MaterialSpawner>().SpawnPair();
        }
        
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
