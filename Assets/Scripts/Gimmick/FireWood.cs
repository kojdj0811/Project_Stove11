using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FireWood : MonoBehaviour
{
    public bool isFake = false;

    public string getFireWoodSound;
    public GameObject fx;
    public float RotateSpeed = 100.0f;
    private void Update()
    {
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(isFake) {
                MinsuTransitionManager.DoRetryTransition();
                return;
            }

            other.GetComponent<jdj.WanderfullCharacterController>();
            if (other)
            {
                //jdj.WanderfullCharacterController.S.WoodCount++;
                GameManager.instance.PickupFirewood();

                gameObject.SetActive(false);

                if(fx != null) {
                    GameObject go = Instantiate(fx);
                    go.SetActive(true);
                    go.transform.position = transform.position;
                }

                if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlayEffect(getFireWoodSound);
                }
            }
        }
    }

}














