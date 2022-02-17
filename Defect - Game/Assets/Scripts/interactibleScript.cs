using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]


public abstract class interactibleScript : MonoBehaviour
{
    private void reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();
    public abstract void Interact(bool isMainChar);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            collision.GetComponent<playerMovementScript>().canInteract = true;
            collision.GetComponent<playerMovementScript>().OpenInteractIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer"))
        {
            collision.GetComponent<playerMovementScript>().canInteract = false;
            collision.GetComponent<playerMovementScript>().CloseInteractIcon();
        }
    }
}
