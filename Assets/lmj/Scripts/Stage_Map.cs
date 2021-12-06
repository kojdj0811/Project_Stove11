using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Stage_Map : MonoBehaviour
{
    [SerializeField]
    GameObject stage1;

    [SerializeField]
    GameObject stage2;

    [SerializeField]
    GameObject stage3;

    [SerializeField]
    GameObject stage4;

    [SerializeField]
    GameObject stage5;
    
    [SerializeField]
    GameObject clearObj_01;

   [SerializeField]
    GameObject clearObj_02;

   [SerializeField]
    GameObject clearObj_03;

   [SerializeField]
    GameObject clearObj_04;
    
   [SerializeField]
    GameObject clearObj_05;

    private void Start()
    {
        var stageInfo = StageManager.instance.StageClearinfo();
        Setup(stageInfo.Item1, stageInfo.Item2, stageInfo.Item3, stageInfo.Item4, stageInfo.Item5);
    }

    void Setup(bool isStage_1, bool isStage_2, bool isStage_3, bool isStage_4, bool isStage_5)
    {
        if (isStage_1)
            clearObj_01.SetActive(true);
        else
            clearObj_01.SetActive(false);

        if (isStage_2)
            clearObj_02.SetActive(true);
        else
            clearObj_02.SetActive(false);

        if (isStage_3)
            clearObj_03.SetActive(true);
        else
            clearObj_03.SetActive(false);

        if (isStage_4)
            clearObj_04.SetActive(true);
        else
            clearObj_04.SetActive(false);

        if (isStage_5)
            clearObj_04.SetActive(true);
        else
            clearObj_04.SetActive(false);

    }
}



























































