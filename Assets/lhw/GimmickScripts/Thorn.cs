using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                Debug.Log("replay");
                // 플레이어 리젠
                MinsuTransitionManager.DoRetryTransition();
                // 가시에 찔리는 사운드
            }
        }
    }
}
