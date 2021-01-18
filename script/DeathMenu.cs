using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    //public Text score;

    public ScoreScript thescoreScript;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        //thescoreScript=FindObjectOfType<ScoreScript>();
    }

	// public void ToggelEndMenu(float score)
	// {
	// 	gameObject.SetActive(true);
	// 	//score.text = ((int)score).ToString();
	// }

    public void Restart()
	{
	 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		ScoreScript.scoreValue = 0;
	}

    public void MainMenu()
    {
        Application.LoadLevel(0);
        ScoreScript.scoreValue = 0;
    }
    public void Next(string lvname)
    {
         SceneManager.LoadScene(lvname);
         ScoreScript.scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}