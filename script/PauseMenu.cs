using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public ScoreScript thescoreScript;
    public static bool GameIsPaused = false; 

	public GameObject pausePanel;

    // public void PauseControl()
    // {
    // 	if(Time.timeScale == 1)
    // 	{
    // 		pausePanel.SetActive (true);
    // 		Time.timeScale = 0;
    // 	} else{
    // 		Time.timeScale = 1;
    // 		pausePanel.SetActive (false);
    // 	}
    // }

    public void Pause()
   {
      pausePanel.SetActive (true);
      Time.timeScale = 0;
      GameIsPaused = true;
   }


   public void Resume()
   {
      pausePanel.SetActive (false);
      Time.timeScale = 1;
      GameIsPaused = false;
   }

    public void Restart()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	Time.timeScale = 1;
        ScoreScript.scoreValue = 0;
    }

    public void MenuUtama()
    {
    	Application.LoadLevel(0);
        ScoreScript.scoreValue = 0;
    }
}
