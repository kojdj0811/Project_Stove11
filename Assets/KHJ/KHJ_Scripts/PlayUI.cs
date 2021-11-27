using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayUI : MonoBehaviour
{
     public static UIManager instance;


    [Header("effect 이름")]
    public string clickClip;
    public string zoomClip;


    [Header("Panel")]
    // public RectTransform title;

    // public RectTransform main;

    // public RectTransform getOutitle;

    public  GameObject   turnOffQuestionPanel;


    [Header("button")]
    public RectTransform startButton;
    public RectTransform quitButton;

    // GameObject quitQuestionPanel;

/*     private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
{
    if (instance == null)   // 최초 생성
    {
        instance = this;  // 현재의 자기 자신(인스턴스)를 할당
        DontDestroyOnLoad(gameObject);  // 씬 전환되도 자기 자신이 파괴되지 않고 유지되도록
    }
    else  
        Destroy(this.gameObject); 
} */
    void Start()
    {
        // GameObject.Find("QuitQuestionPanel");
        //슬라이드 쓔욱
        // title.DOAnchorPos(Vector2.zero, 1f);

        // startButton.DOScale(new Vector3(.8f, .8f, 0), .5f).SetLoops(-1,LoopType.Yoyo);
        
        // quitButton.DOScale(new Vector3(.8f, .8f, 0), .5f).SetLoops(-1,LoopType.Yoyo);


    }

    public void OnClickTurnOffButton()
    {
        turnOffQuestionPanel.SetActive(true);

    }

    public void OnClickTurnOff_ExitButton()
    {

        turnOffQuestionPanel.SetActive(false);

    }
}
















