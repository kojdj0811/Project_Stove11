using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

//씬로드, 씬 BGM 실행 

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;

        [Header("BGM 이름")]
        public string startBGM;
        public string mainBGM;
        public string stage01_BGM;
        public string stage02_BGM;
        public string stage03_BGM;
        public string stage04_BGM;
        public string stage05_BGM;



    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
{
    if (instance == null)   // 최초 생성
    {
        instance = this;  // 현재의 자기 자신(인스턴스)를 할당
        DontDestroyOnLoad(gameObject);  // 씬 전환되도 자기 자신이 파괴되지 않고 유지되도록
    }
    else 
        Destroy(this.gameObject); 
}

    private void Start()
    {
        StartCoroutine(JudgeScene());
    }


    // 씬이름 판별하고 BGM재생 //씬이름은 추후에 바꿔야함 (테스트)
        public IEnumerator JudgeScene()
    {
        yield return new WaitForSeconds(0.1f);

        if(SceneManager.GetActiveScene().name=="khj_Title")
        {
            SoundManager.instance.PlayBgm(startBGM);

        }
        else if(SceneManager.GetActiveScene().name=="khj_Main")
        {
            SoundManager.instance.PlayBgm(mainBGM);

        }
        else if(SceneManager.GetActiveScene().name=="Stage01")
        {
            SoundManager.instance.PlayBgm(stage01_BGM);
        }
        else if(SceneManager.GetActiveScene().name=="Stage02")
        {
            SoundManager.instance.PlayBgm(stage02_BGM);
        }
        else if(SceneManager.GetActiveScene().name=="Stage03")
        {
            SoundManager.instance.PlayBgm(stage03_BGM);
        }      
        else if(SceneManager.GetActiveScene().name=="Stage04")
        {
            SoundManager.instance.PlayBgm(stage04_BGM);
        }
        else if(SceneManager.GetActiveScene().name=="Stage05")
        {
            SoundManager.instance.PlayBgm(stage05_BGM);
        }                  
        
    }

// 게임 시작하기 버튼 눌렀을 때
    public void OnClickStartButton() //스테이지 고르는 씬으로 간다. (테스트) 일단 플레이로바로
    {
        SceneManager.LoadScene("khj_Play");
        Debug.Log("게임을 시작합니다.");

    }
        public void OnClickQuictButton()
    {
        Application.Quit();
        Debug.Log("게임을 종료합니다.");
    }


/*     public void OnClickInterYes()
    {


    } 
        public void OnClickInterNo()
    {


    }  */


}


































































































































































