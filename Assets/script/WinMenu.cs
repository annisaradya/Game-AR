using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
	public ScoreScript thescoreScript;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

     public void Next(string lvname)
	{
	 	 SceneManager.LoadScene(lvname);
	 	 ScoreScript.scoreValue = 0;	
	}
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
}
