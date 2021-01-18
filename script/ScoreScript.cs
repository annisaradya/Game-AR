using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
	Text score;
    public static bool GameIsOver;

	//public Text Score;

	//private bool isDead = false;

	//public DeathMenu deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;
    	//if(isDead) return;
    	score.text ="Score : " + scoreValue.ToString();
        PlayerPrefs.SetInt("score",scoreValue);
    	//score.text = ((int)score).ToString();
        
    }

    // public void OnDeath()
    // {
    // 	isDead = true;
    // 	//deathMenu.ToggleEndMenu (score);
    // }
}
