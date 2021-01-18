using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
	public float startForce = 15f;
	public int secore;

	Rigidbody2D rb;

    void Start()
		{
			rb = GetComponent<Rigidbody2D>();
			rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
		}

   void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			ScoreScript.scoreValue +=secore;
			//Debug.Log("We Hit A Bomb!");
			Destroy(gameObject);
		}
	}
}