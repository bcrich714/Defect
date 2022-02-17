using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public float time, initialDelay;
    public GameObject sensorArea;
    private bool sensorIsOn = true;

    void Start()
    {
        StartCoroutine(initDelay());
    }

    public IEnumerator switchState()
    {
        //Debug.Log("Start Waiting");
        yield return new WaitForSeconds(time);
        //Debug.Log("Start Switching");
        sensorIsOn = !sensorIsOn;
        sensorArea.SetActive(sensorIsOn);
        StartCoroutine(switchState());
    }

    public IEnumerator initDelay()
    {

        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(switchState());
    }
}
