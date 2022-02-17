using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class exitDoorCheck : interactibleScript
{
    public static exitDoorCheck instance;

    private SpriteRenderer sr;
    public GameObject exitAlert;
    public int textDuration = 3;
    public GameObject screenManager;



    public override void Interact(bool isMainChar)
    {
        if (isMainChar)
        {

            screenManager.GetComponent<pauseScript>().openWinScreen();
            screenManager.GetComponent<pauseScript>().levelCompleted = true;
            Time.timeScale = 0f;
        }
        else
        {
            StartCoroutine(instance.textAppear());
        }
    }

    public override void Interact()
    {

    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        instance = this;
        exitAlert.SetActive(false);
    }

    public IEnumerator textAppear()
    {
        exitAlert.SetActive(true);
        yield return new WaitForSeconds(textDuration);
        exitAlert.SetActive(false);
    }
}
