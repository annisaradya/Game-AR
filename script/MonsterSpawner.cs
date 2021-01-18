using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	public GameObject monsterPrefab;
	public Transform [] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine (SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
    	 while(true)
    	 {
    	 	float delay = Random.Range(minDelay, maxDelay);
    	 	yield return new WaitForSeconds(delay);
    	 //spawn some fruit
    	 	int spawnIndex = Random.Range(0, spawnPoints.Length);
    	 	Transform spawnPoint = spawnPoints[spawnIndex];

    	 	GameObject spawnedMonster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    	 	Destroy(spawnedMonster, 5f);
    	 }

    }
}
