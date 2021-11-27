using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField]
    private List<float> timeLimit;
    int currentStage;

    public float GetTimeLimit()
    {
        if (currentStage > 5) { Debug.LogError("currentStage > 5  cureentstage :" + currentStage);  return -1; }
        else if (currentStage < 1) { Debug.LogError("currentStage < 1 cureentstage :" + currentStage); return -1; }
        return timeLimit[currentStage - 1];
    }


}
