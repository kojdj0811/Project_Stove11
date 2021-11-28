using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinsuTransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public static void DoRetryTransition()
    {
        GameObject fadeOutObj = GameObject.Find("Essential/SceneTransition1/TransitionCanvas/Transition1_fadeOut_shorter");
        if (fadeOutObj != null)
        {
            fadeOutObj.SetActive(true);
        }
        else
        {
            Debug.Log("Error. Couldn't find SceneTransition GameObject.");
        }
    }

    public static void DoReturnToHome()
    {
        GameObject fadeOutObj = GameObject.Find("Essential/SceneTransition1/TransitionCanvas/Transition1_fadeOut");
        if (fadeOutObj != null)
        {
            fadeOutObj.GetComponent<DoTransitionMat>().targetSceneIndex = 1;
            fadeOutObj.SetActive(true);
        }
        else
        {
            Debug.Log("Error. Couldn't find SceneTransition GameObject.");
        }
    }

    public static void DoStartStage(int stageNum)
    {
        GameObject fadeOutObj = GameObject.Find("SceneTransition1/TransitionCanvas/Transition1_fadeOut");
        if (fadeOutObj != null)
        {
            fadeOutObj.GetComponent<DoTransitionMat>().targetSceneIndex = stageNum + 1;
            fadeOutObj.SetActive(true);
        }
        else
        {
            Debug.Log("Error. Couldn't find SceneTransition GameObject.");
        }
    }
}
