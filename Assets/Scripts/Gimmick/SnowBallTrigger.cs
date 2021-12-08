using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallTrigger : MonoBehaviour
{
    public SnowBall Object;
    //public Renderer rend;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Object)
            {
                Object.setSnowBall();
                //rend.enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
