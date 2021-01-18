using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timerr : MonoBehaviour
{
    //public Image loading;
 	public Text timeText;
 	public int minutes;
 	public int sec;
 	int totalSeconds = 0;
 	int TOTAL_SECONDS = 0;
    public Text WinText;
 	
 	public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
    	timeText.text = minutes + " : " + sec;
    	if (minutes > 0)
    	totalSeconds += minutes * 60;
    	if (sec > 0)
   		totalSeconds += sec;
  		TOTAL_SECONDS = totalSeconds;
  		StartCoroutine (second ());
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(GameManager.GameIsOver)
    	{
    		this.enabled = false;
    		return;
    	}

    	if (sec == 0 && minutes == 0) 
    	{
    		gameManager.WinLevel();
			this.enabled = false;

    		WinText.text = "Kamu Menang";
    		StopCoroutine (second ());
    		//FindObjectOfType<GameManager>().WinLevel();
    	}
        
    }
    IEnumerator second()
    {
    	yield return new WaitForSeconds (1f);
    	if(sec > 0)
    	sec--;
    	if (sec == 0 && minutes != 0) 
    	{
    		sec = 60;
    		minutes--;
    	}
    	timeText.text = minutes + " : " + sec;
    	//fillLoading ();
    	StartCoroutine (second ());
    }
}