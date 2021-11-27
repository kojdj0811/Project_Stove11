using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallTrigger : MonoBehaviour
{
    public GameObject Object;
    public Renderer rend;
    private bool isUp = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!isUp && other.tag == "Player")
        {
            isUp = true;
            MovingWall wall = Object.GetComponent<MovingWall>();
            if (wall)
            {
                StartCoroutine(wall.MoveWall());
                rend.enabled = false;
            }
        }
    }
}
