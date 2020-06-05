using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;         //총알 발사위치
    float timer=0.0f;
    float stopTime = 0.5f;
    RaycastHit hit;

    //f레이저를 발사하기 위해서는 라인렌더러가 필요
    //최소 2개의 점이 필요하다
    LineRenderer lr;    //라인 렌더러 컴포넌트


    // Start is called before the first frame update
    void Start()
    {
        //라인 렌더러 컴포넌트추가
        lr = GetComponent<LineRenderer>();
        //**중요***
        //게임 오브젝트는 활성화 비활성화할떄 SetActive()를 사용하지만 컴포넌트는 enabled를 사용한다

    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        FireRay();
    }

    private void Fire()
    {
        //마우스왼쪽버튼 or 왼쪽컨트롤 키
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;
        }
    }

    private void FireRay()
    {
        //마우스왼쪽버튼 or 왼쪽컨트롤 키
        if (Input.GetButtonDown("Fire1"))
        {
            lr.enabled = true;
            //라인 시작점, 끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, pos); //0은 시작점

            //끝점구하기
            //if (Physics.Raycast(transform.position, Vector3.up, out hit)){
            //   Vector3 endPos= hit.point;
            //
            //    lr.SetPosition(1, endPos);    //1은 끝점
            //}

            //위와 같다
            Ray ray = new Ray(transform.position, Vector3.up);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 endPos = hit.point;
                lr.SetPosition(1, endPos);    //1은 끝점

                //if (hit.collider.name != "Top")
                //{
                //    Destroy(hit.collider.gameObject);//충돌한 게임 오브젝트를 삭제
                //}

                if (hit.collider.name.Contains("Enemy"))//Enemy란 이름이 포함이 되어있을 경우를 의미
                {
                    Destroy(hit.collider.gameObject);//충돌한 게임 오브젝트를 삭제
                }
            }
        }

        if (lr.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > stopTime)
            {
                lr.enabled = false;
                timer = 0.0f;
            }
        }
    }
}
