using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class BuildingMaterialSO : ScriptableObject
{
    public enum MaterialType
    {
        Door,
        Window,
        Wall,
        Sealing
    }

    public MaterialType type;
    public float price;
    public GameObject materialPrefab;
}
