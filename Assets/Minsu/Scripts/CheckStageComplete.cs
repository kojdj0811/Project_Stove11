using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStageComplete : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            int woodCount = other.gameObject.GetComponent<jdj.WanderfullCharacterController>().WoodCount;
            Debug.Log("******¿Â¿€∞πºˆ: " + woodCount);
            /*
            int targetWoodCount = Game;

            if (woodCount)*/
        }
    }
}
