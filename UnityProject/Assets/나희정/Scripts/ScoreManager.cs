﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;
   // public TextMeshPro textTxt;

    [SerializeField] private int score = 0;
    public static ScoreManager Instance;
    //private void Awake();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
