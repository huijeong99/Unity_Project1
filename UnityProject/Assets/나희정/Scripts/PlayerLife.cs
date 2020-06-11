using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int life;
    public Text leftLife;

    private void Start()
    {
        life = 3;
        showLife();
    }

    public int getLife()
    {
        return life;
    }

    public void setLife(int num)
    {
        life = num;
    }

    // Update is called once per frame
    public void showLife()
    {
        leftLife.text = life + "X";
    }
}
