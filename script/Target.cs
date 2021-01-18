using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 50f;

	//public int Hurt = 1;
	public bool isDamaging;
	public float damage=10;
	public int secore;
	public GameObject deathEffect;

	public void TakeDamage (float amount)
	{
		if(GameManager.GameIsOver)
    	{
    		this.enabled = false;
    		return;
    	}

		health -= amount;
		if (health <= 0f)
		{
			ScoreScript.scoreValue +=secore;
			Die();
		}
	}
	void Die ()
	{

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		//AudioSource.Play();

		Destroy(gameObject);
	}

	public void OnTriggerStay(Collider col)
	{

		if(col.tag == "Player")
		col.SendMessage((isDamaging)?"TakeDamage":"HealDamege", Time.deltaTime*damage);

	}

}
