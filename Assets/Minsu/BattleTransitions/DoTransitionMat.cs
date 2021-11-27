using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class TransitionCompleteEvent : UnityEvent { }

public class DoTransitionMat : MonoBehaviour
{
    public bool isFadeOut = true;
    public bool isRetry = false;
    public float fadeTime = 1f;
    public float startDelay = 0.5f;
    public Material targetMaterial;
    public string materialValueName = "_Cutoff";
    public TransitionCompleteEvent onComplete;

    private float _cutOff = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnEnable()
    {
        if (isFadeOut)
        {
            targetMaterial.SetFloat(materialValueName, 0f);
            targetMaterial.DOFloat(1f, materialValueName, fadeTime).SetDelay(startDelay).SetEase(Ease.OutCubic).OnComplete(AfterComplete);
        }
        else
        {
            targetMaterial.SetFloat(materialValueName, 1f);
            targetMaterial.DOFloat(0f, materialValueName, fadeTime).SetDelay(startDelay).SetEase(Ease.InCubic).OnComplete(AfterComplete);
        }
    }

    private void AfterComplete()
    {
        if(onComplete != null)
            onComplete.Invoke();

        if (isFadeOut)
        {
            if (!isRetry)
            {
                //Next Stage
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
