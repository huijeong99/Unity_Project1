using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;            //텍스트메시프로 사용
using System;

public class ScoreManager : MonoBehaviour
{
    public int intoNextLevel = 10;//다음 스테이지로 넘어가기 위해 필요한 적 수

    //스코어매니져 싱글톤 만들기
    public static ScoreManager Instance;
    private void Awake() => Instance = this;

    public Text scoreTxt;               //일반 UI 텍스트
    public Text highScoreTxt;           //일반 UI 텍스트
   // public TextMeshProUGUI textTxt;     //텍스트메시프로 텍스트

    int score = 0;
    int highScore = 0;

    //스테이지 넘기기용
    public GameObject enemy;    //에너미 매니저 넣는곳
    public GameObject boss;     //보스 넣는 곳
    
    // Start is called before the first frame update
    void Start()
    {
        //스코어 표시하기
        scoreTxt.text = "Score : " + score;
        //하이스코어 불러오기
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "HighScore : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //하이스코어
        SaveHighScore();

        if (score >= intoNextLevel)
        {
            SetBoss();
        }
    }

    private void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "HighScore : " + highScore;
        }
    }

    //점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        scoreTxt.text = "Score : " + score;

        //텍스트메시 프로는 안됨
      //  textTxt.text = "test : " + score;
    }
   
    public void SetBoss()
    {
        enemy.SetActive(false);
        boss.SetActive(true);
    }
}
