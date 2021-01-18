using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
     public GameObject bombPrefab;
    public Transform [] spawnPoints;

    public float minDelay = .01f;
    public float maxDelay = 10f;
    
    void Start()
    {
        StartCoroutine (SpawnBombs());
    }

     IEnumerator SpawnBombs()
    {
    	while (true)
    	{
    		float delay = Random.Range(minDelay, maxDelay);
    		yield return new WaitForSeconds (delay); 
    		
    		//make a random spawnpoints
    		int spawnIndex = Random.Range(0, spawnPoints.Length);
    		Transform spawnPoint = spawnPoints[spawnIndex];
    		//spawn some fruit
    		GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
    		Destroy(spawnedBomb, 5f);

    	}
    }
}
