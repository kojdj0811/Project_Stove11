using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Leaf : MonoBehaviour
{
    public string jumpSound;
    public float jumpForce = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.attachedRigidbody.AddExplosionForce(jumpForce, other.transform.position, 10.0f, 0.0f, ForceMode.VelocityChange);
            SoundManager.instance.PlayEffect(jumpSound);
            Debug.Log("jumpjump");
            // ����
        }
    }
}





