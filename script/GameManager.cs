using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject DeathMenu;
	public GameObject WinMenu;
	public string nextLevel ="lv2";
	public int levelToUnlock=2;
	public Text scoretext;

	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (GameIsOver)
			return;

		// if (PlayerHealth.hitpoint <= 0)
		// {
		// 	EndGame();
		// }
	}

	public void EndGame ()
	{
		GameIsOver = true;
		scoretext.text = "Selamat Point Kamu : " + PlayerPrefs.GetInt("score").ToString();
		DeathMenu.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		scoretext.text = "Selamat Point Kamu : " + PlayerPrefs.GetInt("score").ToString(); 
		WinMenu.SetActive(true);
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
	}

}
