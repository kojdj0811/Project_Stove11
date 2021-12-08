using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeFireWood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // Á×´Â ¼Ò¸®
            }
        }
    }
}
