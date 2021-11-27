using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float slowRate = 0.5f;
    public float originSpeed = 1.0f;
    private bool isSlow = false;


    private void Start()
    {
        originSpeed = jdj.WanderfullCharacterController.S.forwardSpeed;
    }

    // µ¢±¼
    private void OnTriggerEnter(Collider other)
    {
        if(!isSlow ||other.tag == "Player")
        {
            isSlow = true;
            jdj.WanderfullCharacterController.S.forwardSpeed = originSpeed * slowRate;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isSlow || other.tag == "Player")
        {
            isSlow = false;
            jdj.WanderfullCharacterController.S.forwardSpeed = originSpeed;
        }
    }
}
