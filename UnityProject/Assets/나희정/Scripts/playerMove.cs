using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 5.0f;  //플레이어 이동 속도
    public Vector2 margin;  //뷰포트의 좌표 0,0f~0.1f사이

    //조이스틱 사용
    public VariableJoystick joyStick;

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();//alt+enter->enter : 새로운 함수 생성
    }

    //플레이어 이동
    private void Move()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //조이스틱 사용하기
        //키보드가 안눌렸을때 조이스틱 사용
        if (h == 0 && v == 0)
        {
            h = joyStick.Horizontal;
            v = joyStick.Vertical;
        }

        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime,0,0);
        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        //위치= 현재 위치+방향*시간
        //P=P0_vt;
        //transform.position = transform.position + (dir * speed * Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;

        //플레이어를 화면 안에 가두기

        //1. 화면 밖 4방에 큐브 4개를 만들어 충돌처리
        //2. 플레이어의 포지션으로 이동처리
        //캐스팅(현재 위치를 백터에 대입하고 다시 백터를 포지션에 대입하는 방법)
        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);//최솟값과 최대값의 사이로 가두는 함수
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;

        //3. 메인 카메라의 뷰포트를 가져와서 처리
        //스크린 좌표 : 왼쪽 하단(0,0), 우측 상단(maxX,maxY)
        //뷰포트 좌표 : 왼쪽 하단(0,0), 우측 상단(1.0f,1.0f)
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //world공간의 좌표를 뷰포트로 가져옴

        //if (pos.x < 0f) pos.x = 0f;
        //if (pos.x > 1f) pos.x = 1f;
       // pos.x = Mathf.Clamp(pos.x, 0.0f, 1.0f);

        //if (pos.y < 0f) pos.y = 0f;
        //if (pos.y > 1f) pos.y = 1f;
       // pos.y = Mathf.Clamp(pos.y, 0.0f, 1.0f);

        pos.x = Mathf.Clamp(pos.x, 0.0f+margin.x, 1.0f-margin.x);
        pos.y = Mathf.Clamp(pos.y, 0.0f+margin.y, 1.0f-margin.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
