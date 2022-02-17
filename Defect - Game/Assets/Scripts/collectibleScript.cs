using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleScript : MonoBehaviour
{
    public GameObject master;
    public int id;
    public AudioSource collectibleSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            collectibleSound.Play();
            Destroy(gameObject);
            statTracker.totalCollectibles++;
            master.GetComponent<gameMasterScript>().gotCollectible(id);
        }
    }
}
