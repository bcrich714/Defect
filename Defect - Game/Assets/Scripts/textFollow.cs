using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFollow : MonoBehaviour
{
    private Transform target = null;
    public bool play = true;

    private float nextSearchTime = 0;
    private float searchDelay = 1;
    public float xOffset, yOffset;

    public string attachToPlayer;

    private void Update()
    {
        if (target == null)
        {
            FindPlayer();
            return;
        }
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position;
        targetPosition.x += xOffset;
        targetPosition.y += yOffset;

        transform.position = targetPosition;
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    void FindPlayer()
    {
        if (nextSearchTime <= Time.time)
        {
            GameObject searchRes = GameObject.FindGameObjectWithTag(attachToPlayer);
            if (searchRes != null)
            {
                target = searchRes.transform;
            }
            else nextSearchTime = Time.time + searchDelay;
            
        }
    }
}
