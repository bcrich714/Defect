using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class buttonSystemTest : MonoBehaviour
{
    public int target;
    private int pointTotal = 0;
    private bool isActive = false;

   public void addPoint()
    {
        pointTotal++;
        Debug.Log("Current = " + pointTotal);
        checkTotal();
    }

    public void subtractPoint()
    {
        pointTotal--;
        Debug.Log("Current = " + pointTotal);
        checkTotal();
    }

    private void checkTotal()
    {
        if (pointTotal >= target && !isActive)
        {
            isActive = true;
            GetComponent<TilemapRenderer>().enabled = !GetComponent<TilemapRenderer>().enabled;
            GetComponent<TilemapCollider2D>().enabled = !GetComponent<TilemapCollider2D>().enabled;
        }
        else if (pointTotal < target && isActive)
        {
            isActive = false;
            GetComponent<TilemapRenderer>().enabled = !GetComponent<TilemapRenderer>().enabled;
            GetComponent<TilemapCollider2D>().enabled = !GetComponent<TilemapCollider2D>().enabled;
        }
    }


    
}
