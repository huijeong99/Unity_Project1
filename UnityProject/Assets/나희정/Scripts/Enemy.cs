using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    PlayerLife playerLife;

    //위에서 아래로 낙하함
    //충돌처리(에너미<>플레이어/에너미<>플레이어 총알
    private float HP;
    private float maxHP;
    public Image hpBar;

    public float speed;
    public GameObject fxFactory;
    public GameObject crashFx;
    float destroyTimer = 0.0f;

    private void Start()
    {
        speed = UnityEngine.Random.Range(2.0f,4.0f);
        HP = UnityEngine.Random.Range(10.0f, 15.0f);//10에서 15사이의 랜덤한 HP로 생성됨
        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //gravity를 써도 되지만 무겁다
    }

    private void OnCollisionEnter(Collision collision)//충돌검사시 사용하는 함수
    {
        if (collision.collider.tag.Contains("Bullet")){
            HP -= 5.0f;    //나중에 플레이어 공격력 추가하기
            Destroy(collision.gameObject);//충돌체의 게임 오브젝트를 없앰
        }
        else if(collision.collider.tag.Contains("Player"))
        {
            HP -= 10.0f;   //직접 부딪히는 경우 HP가 더 많이 떨어진다
            //플레이어의 HP도 감소시켜준다(여기서 에러남)
            //int playerHP = playerLife.getLife();
            //playerLife.setLife(2);
            //playerLife.showLife();
        }

        ShowCrashFx();
        SetHPBar();

        //HP가 0이 될 경우 파괴된다
        if (HP <= 0)
        {
            DestroyEnemy(collision);
        }
    }


    private void DestroyEnemy(Collision collision)
    {
        //자기 자신과 오브젝트 둘 다 없앤다
        //Destroy(gameObject,1.0f);//1초 뒤에 없앤다는 의미 
        Destroy(gameObject);//소문자 gameObject는 자기 자신

        ShowEffect();

        //점수추가
        ScoreManager.Instance.AddScore();
    }

    //적 파괴시 보이는 이펙트
    void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
    }

    //충돌시 보이는 이펙트+
    private void ShowCrashFx()
    {
        GameObject fx = Instantiate(crashFx);
        crashFx.transform.position = transform.position;
    }

    private void SetHPBar()
    {
        hpBar.fillAmount = HP / maxHP ;
    }
}
