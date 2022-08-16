using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuilder : MonoBehaviour
{
    public Dictionary<Collectable.CollectableType, GameObject> placeHolder = new Dictionary<Collectable.CollectableType, GameObject>();

    
    [Header("UI Model Placeholders")]
    public GameObject roofPlaceholder;
    public GameObject wallPlaceholder;
    public GameObject windowPlaceholder;
    public GameObject doorPlaceholder;

    public PlayerStatsSO playerStatsSO;

    private void Awake()
    {
        placeHolder[Collectable.CollectableType.Door] = doorPlaceholder;
        placeHolder[Collectable.CollectableType.Roof] = roofPlaceholder;
        placeHolder[Collectable.CollectableType.Wall] = wallPlaceholder;
        placeHolder[Collectable.CollectableType.Window] = windowPlaceholder;
    }

    private void Start()
    {
        BuildHouse();
    }

    public void BuildHouse()
    {
        foreach (var pair in playerStatsSO.playerInventory)
        {
            Debug.Log(pair);
            GameObject holder = placeHolder[pair.Key];
            GameObject item = pair.Value;

            item.transform.position = holder.transform.position;
            item.transform.parent = holder.transform;
        }
    }
}
