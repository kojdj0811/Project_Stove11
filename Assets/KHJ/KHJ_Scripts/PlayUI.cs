using System.Collections;
using System.Collections.Generic;

using DG.Tweening;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class PlayUI : MonoBehaviour
{
    //  public static PlayUI instance;


    [Header("SoundName")]
    public string clickClip;
    public string zoomClip;

    [Header("Panel")]

    // public  GameObject   turnOffQuestionPanel;
    public RectTransform turnOffQuestionPanel_rect;

    [Header("UIParticle")]

    public ParticleSystem retryParticle;

    public void OnClickTurnOffCreateButton()
    {
        SoundManager.instance.PlayEffect(zoomClip);

        turnOffQuestionPanel_rect.DOScale(new Vector3(1, 1, 0), .5f).SetDelay(.25f);

        turnOffQuestionPanel_rect.gameObject.SetActive(true);

    }

    public void OnClickTurnOff_ExitButton()
    {
        SoundManager.instance.PlayEffect(clickClip);
        
        turnOffQuestionPanel_rect.DOScale(new Vector3(.1f, .1f, 0), .5f).SetDelay(.25f);
        StartCoroutine(Wait());
        
    }

   public IEnumerator Wait()
    {
        yield return new WaitForSeconds(.26f);
        turnOffQuestionPanel_rect.gameObject.SetActive(false);
 
    }
    public void OnClickRetry()
    {
        retryParticle.Play();
        SoundManager.instance.PlayEffect(clickClip);  
        // retryButton.DOScale(new Vector3(.5f, .5f, 0), .5f).SetLoops(-1,LoopType.Yoyo);


    }
}


































































































































































































































