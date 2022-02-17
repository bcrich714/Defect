using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointMover : MonoBehaviour
{
    public Transform CPPosition;
    public GameObject checkpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            checkpoint.GetComponent<Transform>().position = CPPosition.GetComponent<Transform>().position;
        }
    }
}
