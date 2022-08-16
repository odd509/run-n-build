using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(PlayerBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerBehaviour()
    {
        // wait for the run
        //dance

        yield return new WaitForSeconds(3);
        Debug.Log("zort");
        player.GetComponent<Animator>().SetTrigger("Dance");

    }
}
