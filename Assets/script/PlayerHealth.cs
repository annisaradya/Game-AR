using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public  Image currentHealthbar;
	public Text ratioText;

	private float hitpoint =75;
	private float maxHitpoint = 75;

	public Text lossText;
	//public DeathMenu deathMenu;
	//public GameManager gameManager;

	private void Start()
	{
		//gameObject.SetActive(false);
		UpdateHealthbar();
		lossText.text="";
	}
	private void UpdateHealthbar()
	{


		float ratio = hitpoint / maxHitpoint;
		currentHealthbar.rectTransform.localScale = new Vector3(ratio,1,1);
		ratioText.text = (ratio*100).ToString("0") + '%';
	}
	private void TakeDamage(float damage)
	{
		if(GameManager.GameIsOver)
    	{
    		this.enabled = false;
    		return;
    	}
    	
		hitpoint -= damage;
		if(hitpoint < 0)
		{
			hitpoint = 0;
			lossText.text = "Tamat";
			Die();
			//deathMenu.ToggelEndMenu (hitpoint);
			FindObjectOfType<GameManager>().EndGame();
		}


		UpdateHealthbar();
	}

	// public void Restart()
	// {
	// 	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	// }

	private void maxHealthealDamage(float heal)
	{
		hitpoint += heal;
		if (hitpoint > maxHitpoint)
			hitpoint = maxHitpoint;

		UpdateHealthbar();
	}

	 void Die()
	{
		Destroy(gameObject);
	}
}