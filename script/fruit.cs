using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
	public GameObject fruitSlicedPrefab;
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
			//col.GetComponent<Score>().scoreValue++;
			ScoreScript.scoreValue +=secore;
			Vector3 direction = (col.transform.position - transform.position).normalized;
			Quaternion rotation = Quaternion.LookRotation(direction);
			GameObject slicedFruit = Instantiate(fruitSlicedPrefab,transform.position, rotation);
			Destroy(slicedFruit,3f);
			Destroy(gameObject); 
		}
	}
}
