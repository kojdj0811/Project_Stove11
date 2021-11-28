using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FireWood : MonoBehaviour
{
    public string getFireWoodSound;
    public GameObject fx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                jdj.WanderfullCharacterController.S.WoodCount++;
                gameObject.SetActive(false);

                GameObject go = Instantiate(fx);
                go.SetActive(true);
                go.transform.position = transform.position;

                if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlayEffect(getFireWoodSound);
                    // Debug.Log("돼?");
                }
            }
        }
    }

}














