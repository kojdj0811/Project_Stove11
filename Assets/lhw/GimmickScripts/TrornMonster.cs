using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrornMonster : MonoBehaviour
{
    public float loadGap = 10f;
    public GameObject path;

    private int direction = 1; //이동속도+방향
    public float speed = 30;

    void Update()
    {
        if (transform.position.x < -loadGap)
        {
            direction = -1;
        }
        else if (transform.position.x > loadGap)
        {
            direction = 1;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed * direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("replay");
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                Debug.Log("replay");
                // 플레이어 죽음
                // 가시 사운드
                // 리젠
            }
        }
    }
}

