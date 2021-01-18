using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintmenu : MonoBehaviour
{
	public static bool GameIsPaused = false; 

	public GameObject panelHint;

   
	public void Hint()
	{
		panelHint.SetActive (true);
		Time.timeScale = 0;
		GameIsPaused = true;
	}

	public void Unhint()
	{
		panelHint.SetActive (false);
		Time.timeScale = 1;
		GameIsPaused = false;
  	}


    // Update is called once per frame
    void Update()
    {
        
    }
}