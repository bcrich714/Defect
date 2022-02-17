using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bottomPathSensor : MonoBehaviour
{
    public GameObject target;

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            target.GetComponent<TilemapRenderer>().enabled = true;
            target.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            target.GetComponent<TilemapRenderer>().enabled = false;
            target.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }
}
