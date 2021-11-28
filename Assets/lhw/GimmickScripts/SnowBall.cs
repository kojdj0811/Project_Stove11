using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBall : MonoBehaviour
{
    public Rigidbody rigid;

    public void setSnowBall()
    {
        rigid.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // ´«¿¡ ±ò¸®´Â »ç¿îµå
        }
    }

}
