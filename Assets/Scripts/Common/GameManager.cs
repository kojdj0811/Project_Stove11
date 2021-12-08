using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class GameManager : MonoSingleton<GameManager>
{
    //[SerializeField]
    //Text timeText = null;

    public bool GameWon { get; set; }

    [HideInInspector]
    public int currentFirewood = 0;
    public int maxFirewood = -1;


    private void Start()
    {
        //Firewood Find
        //findall
        var firewoods = GameObject.FindObjectsOfType<FireWood>();
        maxFirewood = firewoods.Length;
        currentFirewood = 0;
        GameWon = false;

        StartCoroutine(TimeLimit(StageManager.instance.GetTimeLimit()));
    }

    IEnumerator TimeLimit(float _time)
    {
        float t = _time;
        while (t > 0)
        {
            //timeText.text = getParseTime(t);
            UIManager.instance.UpdateTimeLimitText(getParseTime(t));
            yield return new WaitForSeconds(1.0f);
            t -= 1.0f;
        }
        GameLose();
    }
    public void PickupFirewood()
    {
        currentFirewood++;
        UIManager.instance.UpdateWoodText();
    }

    public string getParseTime(float time)
    {
        string t = TimeSpan.FromSeconds(time).ToString("mm\\:ss");
        string[] tokens = t.Split(':');
        return tokens[0] + ":" + tokens[1];
    }

    public string getParseWoodCount()
    {
        if (maxFirewood < currentFirewood)
        {
            Debug.LogError("maxFirewood < currentFirewood");
            var firewoods = GameObject.FindObjectsOfType<FireWood>();
            maxFirewood = firewoods.Length;
            currentFirewood = 0;
        }

        return currentFirewood.ToString() + " / " + maxFirewood.ToString();
    }

    public IEnumerator CheckGoal()
    {
        
        Debug.Log("******장작갯수: " + currentFirewood);

        if (maxFirewood < 0 || maxFirewood <= currentFirewood)//woodCount >= GameManager.instance.maxFirewood)
        {
            GameWon = true;
            //Stage Clear
            GameObject House = GameObject.Find("House_Light");
            if (House != null)
            {
                Light light = House.GetComponent<Light>();
                if(light != null)
                {
                    light.enabled = true;
                }
            }
            else
                Debug.LogError("House_Light Name not found");
            
            yield return new WaitForSeconds(4.0f);

            int currentStageNum = SceneManager.GetActiveScene().buildIndex - 1;
            Debug.Log("===Stage Complete. Return to Home====: " + currentStageNum);

            switch (currentStageNum)
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

            if (StageManager.instance.is1StageClear &&
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
            yield return null;
        }
    }


    public void GameLose()
    {
        Debug.Log("GameLose Event");
        MinsuTransitionManager.DoRetryTransition();
    }

}
