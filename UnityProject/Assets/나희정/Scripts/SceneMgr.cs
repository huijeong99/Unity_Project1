using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    //씬매니저 싱글토 ㄴ만들기
    //씬매니저는 시작,게임,종료씬 모두를 관리해야함
    //씬매니저는 씬이 변경되어도 삭제되어선 안된다
    public static SceneMgr Instance;
    public Image Fade;
    public int alpha = 0;

    private void Awake()
    {
        //씬매니저가 존재한다면 새로 생성되는 씬매니저는 삭제하고 바로 빠져나옴
        if (Instance)
        {
            //즉각적으로 메모리에서 해제시킴
            DestroyImmediate(gameObject);
            return;
        }
        //현재 인스턴스가 없을 경우
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//해당 명령어를 설정ㅇ해주면 씬이 넘어가도 삭제되지 않는다
        }
    }

    //private void Update(string value)
    //{
    //    
    //    //Fade.color = new Color(Fade.color.r, Fade.color.g, Fade.color.b, alpha);
    //}

    public void LoadScene(string value)
    {
        SceneManager.LoadScene(value);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
