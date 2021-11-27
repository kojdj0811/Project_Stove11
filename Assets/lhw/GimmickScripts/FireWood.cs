using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                // ���� ����
                gameObject.SetActive(false);
            }
        }
    }
}
