using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScriptFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish Level");
        }
    }
}
