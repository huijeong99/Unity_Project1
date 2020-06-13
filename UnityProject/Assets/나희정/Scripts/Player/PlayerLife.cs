using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int life;
    public Text leftLife;
    public GameObject gameOver;

    private void Start()
    {
        life = 3;
        showLife();
    }

    private void Update()
    {
        if (life <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public int getLife()
    {
        return life;
    }

    public void setLife(int num)
    {
        life = num;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.tag.Contains("PBullet")){
            life--;
            showLife();
        }
    }

    // Update is called once per frame
    public void showLife()
    {
        leftLife.text = life + "X";
    }
}
