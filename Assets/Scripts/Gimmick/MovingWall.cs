using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float duration;
    private Vector3 startPosition;
    public float wallHeight;

    private float startTime;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public IEnumerator MoveWall()
    {
        startTime = Time.timeSinceLevelLoad;

        while (Time.timeSinceLevelLoad < startTime+duration)
        {
            transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * wallHeight, (Time.timeSinceLevelLoad - startTime)/duration);
            yield return null;
        }
    }
}
