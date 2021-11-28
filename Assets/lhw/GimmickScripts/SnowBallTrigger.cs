using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallTrigger : MonoBehaviour
{
    public GameObject Object;
    public Renderer rend;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SnowBall snow = Object.GetComponent<SnowBall>();
            if (snow)
            {
                snow.setSnowBall();
                rend.enabled = false;
            }
        }
    }
}
