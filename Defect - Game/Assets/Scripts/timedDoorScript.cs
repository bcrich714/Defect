using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class timedDoorScript : MonoBehaviour
{
    public float time, initialDelay;
    public GameObject[] targets;
    private BoxCollider2D hitbox;
    private TilemapRenderer tilemap;

    void Start()
    {
        StartCoroutine(initDelay());
    }

    public IEnumerator switchState ()
    {
        //Debug.Log("Start Waiting");
        yield return new WaitForSeconds(time);
        //Debug.Log("Start Switching");
        foreach (GameObject target in targets)
        {
            target.GetComponent<TilemapRenderer>().enabled = !target.GetComponent<TilemapRenderer>().enabled;
            target.GetComponent<TilemapCollider2D>().enabled = !target.GetComponent<TilemapCollider2D>().enabled;
        }
        StartCoroutine(switchState());
    }

    public IEnumerator initDelay()
    {
        
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(switchState());
    }
}
