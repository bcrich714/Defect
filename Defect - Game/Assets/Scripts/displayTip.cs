using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayTip : MonoBehaviour
{
    public GameObject infoTip;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            infoTip.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoTip.SetActive(false);
    }
}
