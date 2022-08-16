using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class MaterialSpawner : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] roofs;
    public GameObject[] windows;
    public GameObject[] walls;

    public GameObject collectablePrefab;
    private GameObject _collectableObject;

    private Dictionary<Collectable.CollectableType, GameObject[]> itemListDict = new Dictionary<Collectable.CollectableType, GameObject[]>();
    
    public float spawnDistance;
    public float spawnOffset;

    public int spawnCount;
    public float spawnTimer;
    private Vector3 currentPos;

    public PlayerStatsSO PlayerStatsSo;
    
    private void Awake()
    {
        itemListDict.Add(Collectable.CollectableType.Door, doors);
        itemListDict.Add(Collectable.CollectableType.Roof, roofs);
        itemListDict.Add(Collectable.CollectableType.Window, windows);
        itemListDict.Add(Collectable.CollectableType.Wall, walls);
        
        currentPos = transform.position;

        for (int i = 0; i < spawnCount; i++)
        {
            currentPos += Vector3.forward * spawnDistance;
            
            SpawnPair();
        }

    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawnTimer);
        currentPos += Vector3.forward * spawnDistance;
        
        SpawnPair();
        StartCoroutine(Spawner());

    }

    private Collectable.CollectableType RandomiseType()
    {
        int selector = Random.Range(0, 4);

        return selector switch
        {
            0 => Collectable.CollectableType.Door,
            1 => Collectable.CollectableType.Wall,
            2 => Collectable.CollectableType.Window,
            3 => Collectable.CollectableType.Roof,
            _ => Collectable.CollectableType.Door
        };
    }

    private GameObject Spawn(Collectable.CollectableType collectableType, Vector3 spawnPos)
    { 

        _collectableObject = Instantiate(collectablePrefab, spawnPos, collectablePrefab.transform.rotation);
        _collectableObject.GetComponent<Collectable>().type = collectableType;
        
        GameObject[] selectedList = itemListDict[collectableType];
        GameObject selectedItem = selectedList[Random.Range(0, selectedList.Length)];
        GameObject selectedItemInstance = Instantiate(selectedItem, spawnPos, selectedItem.transform.rotation);
        
        selectedItemInstance.transform.parent = _collectableObject.transform;

        float priceBase1 = selectedItemInstance.name.Contains("Expensive") ? 4 : 1;
        float priceBase2 = selectedItemInstance.name[selectedItemInstance.name.Length - 1] > 3 ? 2 : 1;

        
        
        _collectableObject.GetComponent<Collectable>().price = (float) (Math.Pow(PlayerStatsSo.betterBargainLevel, 1.2f) * Random.Range(1, 4) * priceBase1 * priceBase2); 
        
        return _collectableObject;

    }

    private void SpawnPair()
    {
        var first = Spawn(RandomiseType(), currentPos + Vector3.left * spawnOffset); //left spawn
        var second = Spawn(RandomiseType(), currentPos + Vector3.right * spawnOffset); //right spawn

        first.GetComponent<Collectable>().pairItem = second;
        second.GetComponent<Collectable>().pairItem = first;
    }
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Vector3 distancePos = currentPos + Vector3.forward * spawnDistance;
        
        Gizmos.DrawLine(currentPos, currentPos + Vector3.forward * spawnDistance);
        Gizmos.DrawLine(currentPos + Vector3.forward * spawnDistance, currentPos + (Vector3.forward * spawnDistance) + Vector3.left * spawnOffset);
        Gizmos.DrawLine(currentPos + (Vector3.forward * spawnDistance), currentPos + (Vector3.forward * spawnDistance) + Vector3.right * spawnOffset);
        
    }
}
