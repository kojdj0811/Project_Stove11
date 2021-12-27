using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_SceneChange : MonoBehaviour
{
    [SerializeField]
    private int StageNumber = -1;
    private void OnTriggerEnter(Collider other)
    {
        if(StageNumber == -1)
        {
            Debug.LogError("Stage_SceneChange StageNumberError");
            return;
        }
        jdj.WanderfullCharacterController _controller = other.GetComponent<jdj.WanderfullCharacterController>();
        if (_controller)
        {
            Debug.Log(StageNumber + " : Stage ¡¯¿‘");
            StageManager.instance.currentStage = StageNumber - 1;
            MinsuTransitionManager.DoStartStage(StageNumber);
        }
    }
}
