using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

//씬로드, 씬 BGM 실행 

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;

        [Header("BGM 이름")]
        public string titleBGM;
        public string mainBGM;
        public string stage01_BGM;
        public string stage02_BGM;
        public string stage03_BGM;
        public string stage04_BGM;
        public string stage05_BGM;

        [Header("effect 이름")]
        public string clickClip;

    bool check = false;

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
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (SceneManager.GetActiveScene().name == "khj_Title")
            {
                SoundManager.instance.PlayBgm(titleBGM);

            }
            
        }
    }

// 게임 시작하기 버튼 눌렀을 때
    public void OnClickStartButton() //메인 씬으로 간다.// (테스트) 로 Play로 해둠
    {

        //클릭배경음
        SoundManager.instance.PlayEffect(clickClip);

        //titleBGM멈춤
        SoundManager.instance.StopClip();

        //메인 씬로드
        SceneManager.LoadScene("khj_Main");

        //메인BGM
        SoundManager.instance.PlayBgm(mainBGM);

        Debug.Log("메인화면입니다.");

    }
        public void OnClickQuictButton()
    {
        SoundManager.instance.PlayEffect(clickClip);

        Application.Quit();
        Debug.Log("게임을 종료합니다.");
    }

    // (테스트) 용
    public void OnClickTestButton()
    {
        SoundManager.instance.StopClip();

        SceneManager.LoadScene("khj_Play");
        
        SoundManager.instance.PlayBgm(stage01_BGM);

        
    }


}



































































































































































































































































































































































