using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrornMonster : MonoBehaviour
{
    uTools.TweenPosition tweenPosition;
    [SerializeField]
    private float distance = 5.0f;
    private void Start()
    {
        tweenPosition = GetComponent<uTools.TweenPosition>();
        Vector3 from = transform.position + (transform.right * (distance/2.0f));
        Vector3 to = transform.position + (-1* transform.right * (distance / 2.0f));

        tweenPosition.from = from;
        tweenPosition.to = to;

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

