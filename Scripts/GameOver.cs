using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text Score;
    [SerializeField] Text Time;
    [SerializeField] Text Totalscore;
    private int totalscore;
    private int totaltime;

    // Update is called once per frame
    void Update()
    {
        totalscore = UI.Instance.score;
        totaltime = (int)UI.Instance.time;
        Score.text = "Coin : " + Convert.ToString(totalscore);
        Time.text = "Time : " + Convert.ToString(totaltime);
        Totalscore.text = "Your Score: " + Convert.ToString(totalscore + totaltime);
    }
}
