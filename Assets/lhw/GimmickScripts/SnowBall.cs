using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // ´«¿¡ ±ò¸®´Â »ç¿îµå
            }
        }
    }
}
