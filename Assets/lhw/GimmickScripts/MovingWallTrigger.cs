using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallTrigger : MonoBehaviour
{
    public GameObject Object;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Move wall");
            MovingWall wall = Object.GetComponent<MovingWall>();
            if (wall)
            {
                wall.WallUp();
                gameObject.SetActive(false);
            }
        }
    }
}
