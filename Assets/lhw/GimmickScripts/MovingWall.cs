using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float upSpeed;

    public void WallUp()
    {
        Vector3 offset = new Vector3(0, transform.localScale.y, 0);
        transform.position = Vector3.Lerp(transform.position, offset + transform.position, upSpeed);
    }
}
