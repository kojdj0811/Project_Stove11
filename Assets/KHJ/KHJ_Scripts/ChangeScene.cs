using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string starButtonClip;
    public void OnClickStartButton()
    {
        SoundManager.instance.PlaySE(starButtonClip);
        SceneManager.LoadScene("SelectStage");
    }
}






















