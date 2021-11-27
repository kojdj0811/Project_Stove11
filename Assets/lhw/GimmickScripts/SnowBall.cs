using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                Debug.Log("replay");
                // ÇÃ·¹ÀÌ¾î ¸®Á¨
                // ´«¿¡ ±ò¸®´Â »ç¿îµå
            }
        }
    }
}
