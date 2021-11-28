using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckStageComplete : MonoBehaviour
{


    public int maxWood = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            int woodCount = other.gameObject.GetComponent<jdj.WanderfullCharacterController>().WoodCount;
            Debug.Log("******장작갯수: " + woodCount);

            if (maxWood < 0 || maxWood <= jdj.WanderfullCharacterController.S.WoodCount)//woodCount >= GameManager.instance.maxFirewood)
            {
                int currentStageNum = SceneManager.GetActiveScene().buildIndex - 1;
                //Stage Clear
                Debug.Log("===Stage Complete. Return to Home====: " + currentStageNum);

                switch(currentStageNum)
                {
                    case 1:
                        StageManager.instance.is1StageClear = true;
                        break;
                    case 2:
                        StageManager.instance.is2StageClear = true;
                        break;
                    case 3:
                        StageManager.instance.is3StageClear = true;
                        break;
                    case 4:
                        StageManager.instance.is4StageClear = true;
                        break;
                    case 5:
                        StageManager.instance.is5StageClear = true;
                        break;
                }

                if(StageManager.instance.is1StageClear &&
                    StageManager.instance.is2StageClear &&
                    StageManager.instance.is3StageClear &&
                    StageManager.instance.is4StageClear &&
                    StageManager.instance.is5StageClear)
                {
                    //All Cleared
                    MinsuTransitionManager.DoStartStage(6); //일단 6번이 엔딩
                }
                else
                    MinsuTransitionManager.DoReturnToHome();
                
            }
            else
            {
                Debug.Log("===Not Enough Fire Wood====");
            }
        }
    }
}
