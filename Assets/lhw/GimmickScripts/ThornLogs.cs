using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThornLogs : MonoBehaviour
{
    public float rotateSpeed = 30f;
    
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // 가시에 찔리는 사운드
            }
        }
    }
}
