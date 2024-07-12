using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayForm : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    public bool isMovingUp = true;

    private void FixedUpdate()
    {
        if (isMovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
            if (transform.position == endPoint.position)
            {
                isMovingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
            if (transform.position == startPoint.position)
            {
                isMovingUp = true;
            }
        }
    }
}
