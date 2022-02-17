using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalEscapeScript : MonoBehaviour
{
    public GameObject screenManager, exitAlert;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovementScript>().isMainChar)
        {
            screenManager.GetComponent<pauseScript>().openWinScreen();
            screenManager.GetComponent<pauseScript>().levelCompleted = true;
            Time.timeScale = 0f;
        }
        else
        {
            exitAlert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitAlert.SetActive(false);
    }


}
