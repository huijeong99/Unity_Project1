using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    private float HP=100.0f;
    private float maxHP=100.0f;
    public Image hpBar;
    public Text leftHP;
    public GameObject fxFactory;
    public GameObject crashFx;

    public GameObject gameClear;

    private void Update()
    {
        if (gameObject.activeSelf==true&&gameObject.transform.position.y >= 5)
        {
            gameObject.transform.position += Vector3.down *1.0f* Time.deltaTime;
        }

        if (HP <= 50 && gameObject.transform.position.y >= 3)
        {
            gameObject.transform.position += Vector3.down * 1.0f * Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)//충돌검사시 사용하는 함수
    {
        if (collision.gameObject.tag.Contains("PBullet"))
        {
            HP -= 5.0f;   
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            //오브젝트풀에 추가만 해준다
            PlayerFire pf = GameObject.Find("Player").GetComponent<PlayerFire>();
            pf.bulletPool.Enqueue(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("MBullet"))
        {
            HP -= 3.0f;
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag.Contains("Player"))
        {
            HP -= 10.0f;   //직접 부딪히는 경우 HP가 더 많이 떨어진다
            //플레이어의 HP도 감소시켜준다(여기서 에러남)
            //int playerHP = playerLife.getLife();
            //playerLife.setLife(2);
            //playerLife.showLife();
        }
        SetHPBar();
        ShowCrashFx();

        //HP가 0이 될 경우 파괴된다
        if (HP <= 0)
        {
            DestroyEnemy(collision);
            gameClear.SetActive(true);
        }
    }


    private void DestroyEnemy(Collision collision)
    {
        //자기 자신과 오브젝트 둘 다 없앤다
        //Destroy(gameObject,1.0f);//1초 뒤에 없앤다는 의미 
        Destroy(gameObject);//소문자 gameObject는 자기 자신

        ShowEffect();
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
        hpBar.fillAmount = HP / maxHP;
        leftHP.text = HP + "/" + maxHP;
    }

    public void setHP(float damage)
    {
        HP -= damage;
    }
}
