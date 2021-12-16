using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingWall : MonoBehaviour
{
    public float speed;
    private Vector3 upPosition;
    private Vector3 downPosition;
    public bool flag = false;

    public float wallHeight;
    int direction = 1;

    private float startTime;

    private void Awake()
    {
        upPosition = transform.position + Vector3.up* wallHeight;
        downPosition = transform.position + Vector3.up * wallHeight * (-1);

        startTime = Time.timeSinceLevelLoad;
    }
    private void Update()
    {
        float step = speed * Time.deltaTime; 
        if(flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, upPosition, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, downPosition, step);
        }

        if (Mathf.Approximately(transform.position.y, upPosition.y) || Mathf.Approximately(transform.position.y, downPosition.y))
        {
            flag = !flag;
        }

    }


 
}
