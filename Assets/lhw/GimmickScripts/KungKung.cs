using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KungKung : MonoBehaviour
{
    public float duration;
    public float waitTime;
    public float force;

    private Vector3 startPosition;
    private float startTime;
    

    private void Awake()
    {
        startPosition = transform.position;
    }

    public IEnumerator initPosition()
    {
        startTime = Time.timeSinceLevelLoad;
        while (Time.timeSinceLevelLoad < startTime + duration)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition+Vector3.up*1.0f, (Time.timeSinceLevelLoad - startTime) / duration);
            if (transform.position.y >= startPosition.y) break;
            yield return null;
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Floor")
        {
            while (true)
            {
                float wTime = waitTime;
                wTime -= Time.deltaTime;
                if (wTime < 0)
                {
                    StartCoroutine(initPosition());
                }
            }
        }
    }
}
