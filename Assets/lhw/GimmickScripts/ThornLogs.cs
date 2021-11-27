using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log("replay");
                // 플레이어 리젠
                // 가시에 찔리는 사운드
            }
        }
    }
}
