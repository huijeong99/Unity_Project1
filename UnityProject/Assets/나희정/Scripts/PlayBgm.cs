using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour
{

   public  GameObject boss;
    public GameObject bgm1;
    public GameObject bgm2;

    // Update is called once per frame
    void Update()
    {
        if (boss.activeSelf == false)
        {
            if (bgm2.activeSelf == true)
            {
                bgm2.SetActive(false);
            }

            bgm1.SetActive(true);
        }

        else
        {
            if (bgm1.activeSelf == true)
            {
                bgm1.SetActive(false);
            }

            bgm2.SetActive(true);
        }
    }
}
