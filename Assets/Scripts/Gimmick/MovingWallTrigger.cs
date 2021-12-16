using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallTrigger : MonoBehaviour
{
    public GameObject Object;
    //public Renderer rend;
    //private bool isUp = false;


    //private void OnCollisionEnter(Collision other)
    //{
    //    jdj.WanderfullCharacterController player = other.transform.GetComponent<jdj.WanderfullCharacterController>();
    //    if (!isUp && player != null)
    //    {
    //        isUp = true;
    //        MovingWall wall = Object.GetComponent<MovingWall>();
    //        if (wall)
    //        {
    //            StartCoroutine(wall.MoveWall());
    //            //rend.enabled = false;
    //        }
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    jdj.WanderfullCharacterController player = other.GetComponent<jdj.WanderfullCharacterController>();
    //    if (!isUp && player != null)
    //    {
    //        isUp = true;
    //        MovingWall wall = Object.GetComponent<MovingWall>();
    //        if (wall)
    //        {
    //            StartCoroutine(wall.MoveWall());
    //            rend.enabled = false;
    //        }
    //    }
    //}
}
