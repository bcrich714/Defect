using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]

public class buttonPressScript : interactibleScript
{
    public Sprite pressed;
    public Sprite unpressed;
    public GameObject[] targets;
    public AudioSource buttonPress;

    private SpriteRenderer sr;
    private bool isPressed = false;

    public override void Interact()
    {
        if (!isPressed)
        {
            sr.sprite = pressed;
            buttonPress.Play();
            foreach (GameObject target in targets)
            {
                target.GetComponent<TilemapRenderer>().enabled = !target.GetComponent<TilemapRenderer>().enabled;
                if (target.TryGetComponent(out TilemapCollider2D sample))
                {
                    target.GetComponent<TilemapCollider2D>().enabled = !target.GetComponent<TilemapCollider2D>().enabled;
                }
            }
        }
        else
        {
            sr.sprite = unpressed;
            buttonPress.Play();
            foreach (GameObject target in targets)
            {
                target.GetComponent<TilemapRenderer>().enabled = !target.GetComponent<TilemapRenderer>().enabled;
                if (target.TryGetComponent(out TilemapCollider2D sample))
                {
                    target.GetComponent<TilemapCollider2D>().enabled = !target.GetComponent<TilemapCollider2D>().enabled;
                }
            }
        }

        isPressed = !isPressed;
    }



    public override void Interact(bool isMainChar)
    {
        Interact();
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = unpressed;
    }
}
