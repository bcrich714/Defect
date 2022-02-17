using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    [Range(1,10)]
    public float smoothValue;
    public float leftMostPoint, rightMostPoint, topMostPoint, bottomMostPoint;
    public bool play = true;

    private float nextSearchTime = 0;
    private float searchDelay = 1;

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        Follow();
    }

    void Update()
    {
        if (target == null)
        {
            FindPlayer();
        }
    }


    void Follow()
    {
        Vector3 targetPosition = target.position + cameraOffset;
        if (targetPosition.x < leftMostPoint && play) targetPosition.x = leftMostPoint;
        if (targetPosition.y > topMostPoint && play) targetPosition.y = topMostPoint;
        if (targetPosition.x > rightMostPoint && play) targetPosition.x = rightMostPoint;
        if (targetPosition.y < bottomMostPoint && play) targetPosition.y = bottomMostPoint;
        Vector3 smoothening = Vector3.Lerp(transform.position, targetPosition, smoothValue*Time.fixedDeltaTime);
        transform.position = smoothening;
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    void FindPlayer ()
    {
        if (nextSearchTime <= Time.time)
        {
           GameObject searchRes = GameObject.FindGameObjectWithTag("Player");
            if (searchRes != null)
            {
                target = searchRes.transform;
                target.GetComponent<playerMovementScript>().isActive = true;
                target.GetComponent<Animator>().SetBool("isMoving", true);
                GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                gm.GetComponent<gameMasterScript>().basePlayerActive = true;

            }
            else
            {
                searchRes = GameObject.FindGameObjectWithTag("SidePlayer");
                if (searchRes != null)
                {
                    target = searchRes.transform;
                    target.GetComponent<playerMovementScript>().isActive = true;
                    GameObject gm = GameObject.FindGameObjectWithTag("GameController");
                    gm.GetComponent<gameMasterScript>().basePlayerActive = false;
                }
                else nextSearchTime = Time.time + searchDelay;
            }
        }
    }
}
