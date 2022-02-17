using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class detectActiveRobot : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")  || collision.CompareTag("SidePlayer"))
        {
            if (collision.GetComponent<playerMovementScript>().isActive)
            {
                target.GetComponent<TilemapRenderer>().enabled = true;
                target.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }
    }
}
