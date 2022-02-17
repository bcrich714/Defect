using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoSpeechTrigger : MonoBehaviour
{
    public GameObject textBubble;
    public BoxCollider2D boxCollider;
    public int textDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            boxCollider.enabled = false;
            StartCoroutine(textAppear());
        }
    }

    public IEnumerator textAppear()
    {
        textBubble.SetActive(true);
        yield return new WaitForSeconds(textDuration);
        textBubble.SetActive(false);
    }
}
