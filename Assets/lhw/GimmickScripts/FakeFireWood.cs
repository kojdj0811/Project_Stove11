using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFireWood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                // �÷��̾� ����
                // �״� �Ҹ�
            }
        }
    }
}
