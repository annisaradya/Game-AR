using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    public static bool GameIsOver;

    void Start()
    {
        score = GetComponent<Text>();
    }

 
    void Update()
    {
        if (GameIsOver)
            return;
        //if(isDead) return;
        score.text ="Score : " + scoreValue.ToString();
        PlayerPrefs.SetInt("score",scoreValue);
    }
}
