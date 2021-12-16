using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    bool flag = false;
    public float destroyTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && flag == false)
        {
            flag = true;
            Destroy(transform.gameObject, destroyTime);
        }
    }

}
