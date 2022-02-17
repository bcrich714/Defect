using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(BoxCollider2D))]

public class pressureButtonScript : MonoBehaviour
{
    //MODE DETERMINES THE METHOD OF ACTIVATION OF TARGETS
    //MODE 0: ENABLE/DISABLE (MULTIPLE PLATES EACH CHANGE THE STATE)
    //MODE 1: TARGET (MULTIPLE PLATES CHANGE THE STATE ONLY ONCE AND ONLY IF THE TARGET PLATES ARE ACTIVE)
    public int mode;

    public GameObject[] targets;
    public Sprite pressed, unpressed;
    private SpriteRenderer sr;
    private int amountOnPlate = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        amountOnPlate++;
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer") && amountOnPlate == 1)
        {
            sr.sprite = pressed;

            foreach (GameObject target in targets)
            {
                if (mode == 1) target.GetComponent<buttonSystemTest>().addPoint();
                else
                {
                    target.GetComponent<TilemapRenderer>().enabled = !target.GetComponent<TilemapRenderer>().enabled;
                    target.GetComponent<TilemapCollider2D>().enabled = !target.GetComponent<TilemapCollider2D>().enabled;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        amountOnPlate--;
        if (collision.CompareTag("Player") || collision.CompareTag("SidePlayer") && amountOnPlate == 0)
        {
            sr.sprite = unpressed;
            foreach (GameObject target in targets)
            {
                if (mode == 1)  target.GetComponent<buttonSystemTest>().subtractPoint();
                else
                {
                    target.GetComponent<TilemapRenderer>().enabled = !target.GetComponent<TilemapRenderer>().enabled;
                    target.GetComponent<TilemapCollider2D>().enabled = !target.GetComponent<TilemapCollider2D>().enabled;
                }
            }
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = unpressed;
    }
}
