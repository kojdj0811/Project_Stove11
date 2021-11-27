using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    Text timeText = null;

    [SerializeField]
    Text woodCountText = null;

    public bool GameWon { get; set; }
    public bool GameLost { get; set; }
    public int currentFirewood = 0;
    int maxFirewood = -1;


    private void Start()
    {
        //Firewood Find
        //findall
        var firewoods = GameObject.FindObjectsOfType<FireWood>();
        maxFirewood = firewoods.Length;
        currentFirewood = 0;
        GameWon = false;
        GameLost = false;

        StartCoroutine(TimeLimit(StageManager.instance.GetTimeLimit()));
    }

    IEnumerator TimeLimit(float _time)
    {
        float t = _time;
        while (t > 0 && GameLost == false && GameWon == false)
        {
            timeText.text = getParseTime(t);
            yield return new WaitForSeconds(1.0f);
            t -= 1.0f;
        }
        GameLose();
    }

    string getParseTime(float time)
    {
        string t = TimeSpan.FromSeconds(time).ToString("mm\\:ss");
        string[] tokens = t.Split(':');
        return tokens[0] + ":" + tokens[1];
    }

    string getParseWoodCount(int woodCount)
    {
        if (maxFirewood < currentFirewood)
        {
            Debug.LogError("maxFirewood < currentFirewood");
            return "maxFirewood < currentFirewood";
        }
        return currentFirewood.ToString() + " : " + maxFirewood.ToString();
    }

    public void CheckGoal()
    {
        if(maxFirewood < currentFirewood)
        {
            Debug.LogError("maxFirewood < currentFirewood");
        }
        else if(maxFirewood == currentFirewood)
        {
            GameWin();
        }
    }


    public void GameLose()
    {
        Debug.Log("GameLose Event");
    }

    void GameWin()
    {
        Debug.Log("GameWin Event");
    }

}
