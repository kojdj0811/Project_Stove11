using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public Text text;




    void Update()
    {
        float time = Time.timeSinceLevelLoad;
        
        int min = (int)time/60;
        int sec = (int)time%60;

        text.text = $"{min:00} : {sec:00}";
    }
}
