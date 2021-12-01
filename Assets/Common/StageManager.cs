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

    public bool is1StageClear = false;
    public bool is2StageClear = false;
    public bool is3StageClear = false;
    public bool is4StageClear = false;
    public bool is5StageClear = false;

    public bool GetstageClear(int stageNum)
    {
        switch(stageNum)
        {
            case 1:
                return is1StageClear;
            case 2:
                return is2StageClear;
            case 3:
                return is3StageClear;
            case 4:
                return is4StageClear;
            case 5:
                return is5StageClear;
        }
        Debug.LogError("StageNumber Errror" + stageNum);
        return false;
    }

    public Tuple<bool, bool, bool, bool, bool>  StageClearinfo(){ return new Tuple<bool, bool, bool, bool, bool>(is1StageClear, is2StageClear, is3StageClear, is4StageClear, is5StageClear); }
    public float GetTimeLimit()
    {
        if (currentStage > 4) { Debug.LogError("currentStage > 4  cureentstage :" + currentStage);  return -1; }
        else if (currentStage < 0) { Debug.LogError("currentStage < 0 cureentstage :" + currentStage); return -1; }
        if (timeLimit != null)
            return timeLimit[currentStage];
        Debug.LogError("StageManager timeLimit Null GetTimeLimit");
        return 90.0f;
    }


}
