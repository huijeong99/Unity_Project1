using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System; <이게 있으면 랜덤한수 사용불가

public class EnemyManager : MonoBehaviour
{
    //에너미매니저의 역할:에너미를 공장에서 찍어낸다(에너미 프리펩)
    //1.에너미 스폰타임
    //2.에너미 스폰위치

    public GameObject enemyFactory;
    //public GameObject spawnPoint[5];
    public GameObject spawnPoint;
    float spawnTime=1.0f;    //스폰타임
    float curTime=0.0f;      //

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발생
        //시간 누적타임으로 계산

        curTime += Time.deltaTime;

        if (curTime > spawnTime)
        {
            //스폰타임을 랜덤으로
            spawnTime = Random.Range(0.5f, 2.0f);
            
            //에너미 생성
            GameObject enemy = Instantiate(enemyFactory);

            //에너미 생성 위치 조정
             enemy.transform.position = spawnPoint.transform.position;
            int index = Random.Range(0, 5);//SpawnPoints.lenghs
            //enemy.transform.position = spawnPoint[index].transform.position;

            //누적시간 초기화
            curTime = 0.0f;
        }
    }
}
