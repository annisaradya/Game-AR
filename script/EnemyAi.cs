using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
	Transform playerTransform;
	UnityEngine.AI.NavMeshAgent myNavmesh;
	public float checkRate = 0.01f;
	float nextCheck;
	
    // Start is called before the first frame update
    void Start()
    {
    	//GetComponent<AudioSource> ().Play ();
    	//AudioSource.Play();
    	StartCoroutine ("Move");

        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    	myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
    	transform.Translate(Vector3.forward * 3f * Time.deltaTime);
        if (Time.time > nextCheck)
        {
        	nextCheck = Time.time + checkRate;
        	FollowPlayer();
        }

    }
    void FollowPlayer()
    {
    	myNavmesh.transform.LookAt(playerTransform);
    	myNavmesh.destination = playerTransform.position;
    }
    IEnumerator Move() 
  	{
  		//WaveSpawn.EnemiesAlive--;

  		while (true) {
	    yield return new WaitForSeconds (3.5f);
	    transform.eulerAngles += new Vector3 (0, 180f, 0);
    }
  }
}
