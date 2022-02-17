using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class hackableRobot : interactibleScript
{
    public static hackableRobot instance;

    private SpriteRenderer sr;
    public GameObject switchAlert;
    int textDuration = 5;
    public AudioSource hackSound;
   



    public override void Interact(bool isMainChar)
    {
        hackSound.Play();
        GameObject[] gm = GameObject.FindGameObjectsWithTag("GameController");
        gm[0].GetComponent<gameMasterScript>().createSecondPlayer();
        GameObject[] hackRobot = GameObject.FindGameObjectsWithTag("NewRobot");
        Vector3 newPos = new Vector3(99999f, 99999f, 0);
        hackRobot[0].GetComponent<Transform>().position = newPos;
        StartCoroutine(instance.textAppear(hackRobot[0]));
        
        //StartCoroutine(instance.textAppear());
    }

    public override void Interact()
    {

    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        instance = this;
        switchAlert.SetActive(false);
    }

    
    public IEnumerator textAppear(GameObject obj)
    {
        switchAlert.SetActive(true);
        yield return new WaitForSeconds(textDuration);
        Destroy(obj);
        switchAlert.SetActive(false);
    }
    
}
