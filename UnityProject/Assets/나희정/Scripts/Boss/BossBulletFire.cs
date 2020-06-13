using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletFire : MonoBehaviour
{
    public GameObject FirePos;       //발사 위치
    public GameObject bulletFactoryA;        //발사하는 총알
    public GameObject bulletFactoryB;        //발사하는 총알
    public GameObject Player;        //플레이어
    public float FireTime = 1.0f;      //총알 발사 시간(1초에 한 번 발사함)
    public float CurrentTime = 0.0f;    //실시간 카운터

    public float FireTime1 = 1.5f;
    float currentTime1 = 0.0f;
    int bulletMax = 10;


    // Update is called once per frame
    void Update()
    {

        AutoFire1();
        AutoFire2();

      
    }

    private void AutoFire1()
    {
        if (Player != null)
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime > FireTime)
            {
                // float degree=Mathf.Atan2(transform.position.y-Player.po9

                //bullet.transform.rotation = Quaternion.Euler(180, 0, 0);
                GameObject bullet = Instantiate(bulletFactoryA);
                //총알생성 위치
                bullet.transform.position = transform.position;
                //플레이어 방향 구하기
                Vector3 dir = Player.transform.position - transform.position;
                dir.Normalize();

                bullet.transform.up = dir;

                CurrentTime = 0.0f;
            }
        }
    }

    private void AutoFire2()
    {
        if (Player != null)
        {
            currentTime1 += Time.deltaTime;
           
            if (currentTime1 > FireTime1)
            {

                for (int i = 0; i < bulletMax; i++)
                {
                  
                    //bullet.transform.rotation = Quaternion.Euler(180, 0, 0);
                    GameObject bullet = Instantiate(bulletFactoryB);
                    //총알생성 위치
                    bullet.transform.position = transform.position;

                    //360도 방향으로 총알발사
                    float angle = 360.0f / bulletMax;

                    //총구의 방향도 맞춰준다(이게 중요함)
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }

                currentTime1 = 0.0f;
            }
        }
    }
}
