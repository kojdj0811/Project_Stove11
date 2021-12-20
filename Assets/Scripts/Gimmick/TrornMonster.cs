using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrornMonster : MonoBehaviour
{
    public float loadGap = 10f;
    private int direction = 1; 
    public float speed = 30;

    private Vector3 upPosition;
    private Vector3 downPosition;
    [HideInInspector]
    public bool flag = false;

    private void Start()
    {
        upPosition = transform.position + Vector3.left * loadGap;
        downPosition = transform.position + Vector3.left * loadGap * (-1);

    }


    void Update()
    {
        //if (transform.position.x < -loadGap)
        //{
        //    direction = -1;
        //}
        //else if (transform.position.x > loadGap)
        //{
        //    direction = 1;
        //}

        //transform.Translate(Vector3.left * Time.deltaTime * speed * direction);




        if (flag)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * direction);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * direction);
        }

        if (Mathf.Approximately(transform.position.x, upPosition.x) || Mathf.Approximately(transform.position.x, downPosition.x))
        {
            flag = !flag;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // 가시 사운드
            }
        }
    }
}

