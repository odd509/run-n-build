using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MaterialSpawner : MonoBehaviour
{
    public GameObject[] materials;
    public float spawnDistance;
    public float spawnOffset;

    public int spawnCount;
    public float spawnTimer;
    private Vector3 currentPos;
    
    private void Awake()
    {
        currentPos = transform.position;

        for (int i = 0; i < spawnCount; i++)
        {
            currentPos += Vector3.forward * spawnDistance;
            GameObject newMaterial = Instantiate(materials[Random.Range(0, materials.Length)], currentPos, Quaternion.identity);
        }

    }

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        currentPos += Vector3.forward * spawnDistance;
        GameObject newMaterial = Instantiate(materials[Random.Range(0, materials.Length)], currentPos, Quaternion.identity);

        StartCoroutine(spawn());

    }
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 currentPos = transform.position;
        Vector3 distancePos = currentPos + Vector3.forward * spawnDistance;
        
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * spawnDistance);
        Gizmos.DrawLine(transform.position + Vector3.forward * spawnDistance, transform.position + (Vector3.forward * spawnDistance) + Vector3.left * spawnOffset);
        Gizmos.DrawLine(transform.position + (Vector3.forward * spawnDistance), transform.position + (Vector3.forward * spawnDistance) + Vector3.right * spawnOffset);
        
    }
}
