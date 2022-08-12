using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class UIEffects : MonoBehaviour
{
    public void PickUp()
    {
        GetComponent<Animator>().SetTrigger("UIBoing");
    }

    
}
