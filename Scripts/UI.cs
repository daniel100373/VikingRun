using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public int score;
    public float time = 0;
    VikingController vikingController;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    public static UI Instance;

    private void Awake()
    {
        vikingController = FindObjectOfType<VikingController>();
        Instance = this;
    }
    public void AddScore()
    {
        
        score++;
        scoreText.text = "Coin : " + Convert.ToString(score / 10) + Convert.ToString(score % 10);
    }

   
    private void Update()
    {
        if( !vikingController.isDied ) 
        {
            time += Time.deltaTime;
            timeText.text = "Time : " + Convert.ToString(Math.Floor((time)));
        }
    }
}
