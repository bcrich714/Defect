using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{

    public string charType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            statTracker.totalDeaths++;
            Destroy(gameObject);
            gameMasterScript.instance.StartCoroutine(gameMasterScript.instance.Respawn(charType));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            statTracker.totalDeaths++;
            Destroy(gameObject);
            gameMasterScript.instance.StartCoroutine(gameMasterScript.instance.Respawn(charType));
        }
    }
}
