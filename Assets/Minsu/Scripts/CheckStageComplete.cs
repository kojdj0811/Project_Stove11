using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStageComplete : MonoBehaviour
{
    //public int maxWood = -1;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag.Equals("Player"))
        //{
        //    //int woodCount = other.gameObject.GetComponent<jdj.WanderfullCharacterController>().WoodCount;
        //    int woodCount = GameManager.instance.currentFirewood;
        //    Debug.Log("******���۰���: " + woodCount);
        //    if (maxWood < 0 || maxWood <= jdj.WanderfullCharacterController.S.WoodCount)//woodCount >= GameManager.instance.maxFirewood)
        //    {
        //        int currentStageNum = SceneManager.GetActiveScene().buildIndex - 1;
        //        //Stage Clear
        //        Debug.Log("===Stage Complete. Return to Home====: " + currentStageNum);
        //        switch(currentStageNum)
        //        {
        //            case 1:
        //                StageManager.instance.is1StageClear = true;
        //                break;
        //            case 2:
        //                StageManager.instance.is2StageClear = true;
        //                break;
        //            case 3:
        //                StageManager.instance.is3StageClear = true;
        //                break;
        //            case 4:
        //                StageManager.instance.is4StageClear = true;
        //                break;
        //            case 5:
        //                StageManager.instance.is5StageClear = true;
        //                break;
        //        }
        //        if(StageManager.instance.is1StageClear &&
        //            StageManager.instance.is2StageClear &&
        //            StageManager.instance.is3StageClear &&
        //            StageManager.instance.is4StageClear &&
        //            StageManager.instance.is5StageClear)
        //        {
        //            //All Cleared
        //            MinsuTransitionManager.DoStartStage(6); //�ϴ� 6���� ����
        //        }
        //        else
        //            MinsuTransitionManager.DoReturnToHome();
        //    }
        //    else
        //    {
        //        Debug.Log("===Not Enough Fire Wood====");
        //    }
        //}

        if (other.gameObject.tag.Equals("Player") && GameManager.instance.GameWon == false)
        {
            StartCoroutine(GameManager.instance.CheckGoal());
        }
    }
}
