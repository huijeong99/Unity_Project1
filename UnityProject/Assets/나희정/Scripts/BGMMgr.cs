using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{
    //BGMMgr 싱글톤 만들기
    //모든 씬에서 사용가능해야함
    public static BGMMgr Instance;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    Dictionary<string, AudioClip> bgmTable;//키값과 오디오 클립을 담음
    AudioSource audioMain;
    AudioSource audioSub;

    [Range(0, 1.0f)]
    public float masterVolume = 1.0f;//마스터볼륨을 0~1사이로만 넣을 수 있도록 인스펙터창에 고정시킴
    float volumeMain = 0.0f;        //메인 오디오 볼륨
    float volumeSub = 0.0f;         //서브오디오 볼륨
    float crossFadeTime = 5.0f;     //크로스페이드타임

    private void Start()
    {
        //bgm 테이블 생성
        bgmTable = new Dictionary<string, AudioClip>();
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();

        //오디오 소스 -으로 초기화
        audioMain.volume = 0.0f;
        audioSub.volume = 0.0f;
    }

    private void Update()
    {
        //bgm 크로스페이드    
        if (audioMain.isPlaying)
        {
            //메인오디오 볼륨올리기
            if (volumeMain < 1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime;
                if (volumeMain >= 1.0f)
                {
                    volumeMain = 1.0f;
                }
            }

            //서브오디오 볼륨내리기
            if (volumeSub > 0.0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if (volumeSub <= 0.0f)
                {
                    volumeSub = 0.0f;
                    audioSub.Stop();
                }
            }
        }

        //볼륨조정
        audioMain.volume = volumeMain * masterVolume;
        audioSub.volume = volumeSub * masterVolume;
    }

    //BGM플레이
    public void PlayBGM(string bgmName)
    {
        //유니티 내에는 리소스라는 폴더가 존재하며 어디에서든 파일을 로드할 수 있다
        //딕셔너리 안에 브금이 없을 경우 리소스 폴더 내에서 파일을 찾아서 넣는다
        if (bgmTable.ContainsKey(bgmName) == false)
        {
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);//내가 가져올 파일이 뭔지 알려줘야한다(요즘은 이 방법으로 씀)
                                                                        // == AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //만일 리소스 폴더에도 bgm 파일이 없을 경우
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);
        }

        //메인오디오의 클립에 새로운 오디오 클립을 연결한다
        audioMain.clip = bgmTable[bgmName];
        //메인오디오를 플레이시킨다
        audioMain.Play();

        //볼륨조절하기
        volumeMain = 1.0f;
        volumeSub = 0.0f;
    }

    //브금 크로스페이드 플레이
    public void CrossFadeBGM(string bgmName,float cfTime=1.0f)
    {
        if (bgmTable.ContainsKey(bgmName) == false)
        {
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);//내가 가져올 파일이 뭔지 알려줘야한다(요즘은 이 방법으로 씀)
                                                                        // == AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //만일 리소스 폴더에도 bgm 파일이 없을 경우
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);
        }

        //크로스페이드 타임
        crossFadeTime = cfTime;

        //메인오디오에서 플레이되고있는걸 서브오디오로 변경
        AudioSource temp = audioMain;
        audioMain = audioSub;
        audioSub = temp;

        //볼륨값 스위칭
        float tempVolume = volumeMain;
        volumeMain = volumeSub;
        volumeSub = tempVolume;

        //메인오디오의 클립에 새로운 오디오 클립을 연결
        audioMain.clip = bgmTable[bgmName];

        audioMain.Play();
    }

    //일시정지
    public void PauseBGM()
    {
        audioMain.Pause();
    }

    //다시 재생
    public void ResumeBGM()
    {
        audioMain.Play();
    }
}
