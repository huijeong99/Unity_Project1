using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
   public void onStartButtonClick()
    {
        SceneMgr.Instance.LoadScene("GameScene");
    }

    public void onMenuButtonClick()
    {

    }

    public void onOptionButtonClick()
    {

    }
}
