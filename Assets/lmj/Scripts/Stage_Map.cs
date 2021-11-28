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

    private void Start()
    {
        var stageInfo = StageManager.instance.StageClearinfo();
        Setup(stageInfo.Item1, stageInfo.Item2, stageInfo.Item3, stageInfo.Item4, stageInfo.Item5);
    }

    void Setup(bool isStage_1, bool isStage_2, bool isStage_3, bool isStage_4, bool isStage_5)
    {
        if (isStage_1)
            stage1.SetActive(false);
        else
            stage1.SetActive(true);

        if (isStage_2)
            stage2.SetActive(false);
        else
            stage2.SetActive(true);

        if (isStage_3)
            stage3.SetActive(false);
        else
            stage3.SetActive(true);

        if (isStage_4)
            stage4.SetActive(false);
        else
            stage4.SetActive(true);

        if (isStage_5)
            stage5.SetActive(false);
        else
            stage5.SetActive(true);
    }
}
