using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;


[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioSource [] audioSourcesEffects;
    public AudioSource audioSourceBgm;

    public string[] playSoundName;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;
    
    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
{
    if (instance == null)   // 최초 생성
    {
        instance = this;  // 현재의 자기 자신(인스턴스)를 할당
        DontDestroyOnLoad(gameObject);  // 씬 전환되도 자기 자신이 파괴되지 않고 유지되도록
    }
    else  // 단 하나만 존재하게끔 새로 생긴 Sound Manager 오브젝트 인스턴스일 경우엔 파괴
        Destroy(this.gameObject); 


}
    private void Start()
    {
    playSoundName = new string[audioSourcesEffects.Length];

    }

    public void PlayEffect(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    if (!audioSourcesEffects[i].isPlaying)
                    {
                        playSoundName[i] = effectSounds[i].name;
                        audioSourcesEffects[i].clip = effectSounds[i].clip;
                        audioSourcesEffects[j].Play();
                        return;

                    }
                }
                Debug.Log("모든 가용 오디오 소스가 사용중입니다.");
                return;
            }
        }
        Debug.Log("사운드가 사운드 매니저에 등록되지 않았습니다.");
    }
    
        public void PlayBgm(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if(_name == bgmSounds[i].name)
            {
                for (int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    if (!audioSourcesEffects[i].isPlaying)
                    {
                        playSoundName[i] = bgmSounds[i].name;
                        audioSourcesEffects[i].clip = bgmSounds[i].clip;
                        audioSourcesEffects[j].Play();
                        return;

                    }
                }
                Debug.Log("모든 가용 오디오 소스가 사용중입니다.");
                return;
            }
        }
        Debug.Log("사운드가 사운드 매니저에 등록되지 않았습니다.");
    }

    
    public void StopAllSE()
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].Stop();
        }

    }

        public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourcesEffects.Length; i++)
        {
            if(playSoundName[i]==_name)
            {
                audioSourcesEffects[i].Stop();
                return;

            }
        }
        Debug.Log("재생중인 "+ _name + " 사운드가 없습니다.");
    }

}


















































































































































