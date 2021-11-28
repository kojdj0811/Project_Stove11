using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressbar;
    public string loadingBGM;

    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;


        SceneManager.LoadScene(1);


        Debug.Log("로딩 지나감");
        
    }

    
    void Start()
    {

        Debug.Log("BGM나옴");

        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        
        while(!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressbar.fillAmount = op.progress;
            }
            else{
                timer += Time.unscaledDeltaTime;
                progressbar.fillAmount = Mathf.Lerp(.9f, 1f, timer);
                if(progressbar.fillAmount >=1f)
                {
                    op.allowSceneActivation = true;
                    yield break;

                }
            }

        }
    }
}




















































































