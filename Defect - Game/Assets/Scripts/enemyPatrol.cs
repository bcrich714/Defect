using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public float speed;

    public float patrolTime;
    private float timeRemaining;
    private bool movingRight = true;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (timeRemaining <= 0)
        {
            timeRemaining = patrolTime;
            if (movingRight)
            {
                movingRight = !movingRight;
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                movingRight = !movingRight;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }

    }
}
