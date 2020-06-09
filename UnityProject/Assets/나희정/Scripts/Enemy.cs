using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //위에서 아래로 낙하함
    //충돌처리(에너미<>플레이어/에너미<>플레이어 총알

    public float speed = 10.0f;
    public GameObject fxFactory;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //gravity를 써도 되지만 무겁다

    }

    private void OnCollisionEnter(Collision collision)//충돌검사시 사용하는 함수
    {
        //자기 자신과 오브젝트 둘 다 없앤다
        //Destroy(gameObject,1.0f);//1초 뒤에 없앤다는 의미 
        Destroy(gameObject);//소문자 gameObject는 자기 자신
        Destroy(collision.gameObject);//충돌체의 게임 오브젝트를 없앰

        ShowEffect();
    }

    void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
    }
}
