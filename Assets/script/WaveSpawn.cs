using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{

	//public static int EnemiesAlive = 0;

	public enum SpawnState {SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public  class Wave
	{
        public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

    public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
    // Start is called before the first frame update
    void Start()
    {
         if(spawnPoints.Length==0)
        {
            Debug.LogError("No Spawn Points referanced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
    	if (state == SpawnState.WAITING)
    	{
    		if (!EnemyIsAlive())
    		{
    			WaveComplated();
    			//return;
    		}
    		else
    		{
    			return;
    		}
    	}
    	if (waveCountdown <=0)
    	{
    		if(state != SpawnState.SPAWNING)
    		{
    			StartCoroutine(SpawnWave ( waves[nextWave]));
    		}
    	}
    	else
    	{
    		waveCountdown -= Time.deltaTime;
    	}
    }

    void WaveComplated()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All WAVE COMPLETE");
        }
        else
        {
            nextWave++;
        }
        
    }
    bool EnemyIsAlive()
    {
    	searchCountdown -= Time.deltaTime;
    	if (searchCountdown <= 0f)
    	{
    		searchCountdown = 1f;
    		if(GameObject.FindGameObjectWithTag("Enemy")==null)
    		{
    			return false;
    		}
    	}
    	return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
    	//Debug.Log("Spawnig Wave;" +_wave.name);
    	state = SpawnState.SPAWNING;
        // while(true)
        // {
        	for (int i = 0; i< _wave.count; i++)
        	{
        		SpawnEnemy(_wave.enemy);
        		yield return new WaitForSeconds(1f/ _wave.rate);
        	}
        	state = SpawnState.WAITING;
        	yield break;

        //     if(gameOver)
        //     {
        //         break;
        //     }
        // }
    }
    void SpawnEnemy(Transform _enemy)
    {

    	Debug.Log("Spawnig Enemy: " + _enemy.name);
        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        //EnemiesAlive++;
    }
    // public void GameOver()
    // {
    //     gameOver = true;
    // }
}













// 	public static int EnemiesAlive = 0;

// 	public enum SpawnState {COUNTING};

// 	[System.Serializable]
// 	public  class Wave
// 	{
//         public string name;
// 		public Transform enemy;
// 		public int count;
// 		public float rate;
// 	}
	
// 	//public Transform enemyPrafeb;

// 	public Wave[] waves;

// 	public Transform[] spawnPoint;

// 	public float timeBetweenWaves = 5f;
// 	private float countdown = 2f;

// 	private int waveIndex = 0;
// 	private float searchCountdown = 1f;

// 	private SpawnState state = SpawnState.COUNTING;

// 	void Start()
//     {
//          if(spawnPoint.Length==0)
//         {
//             Debug.LogError("No Spawn Points referanced.");
//         }

//         countdown = timeBetweenWaves;
//     }

// 	void Update ()
// 	{
// 		if (EnemiesAlive > 0)
// 		{
// 			return;
// 		}
		
// 		if (countdown <= 0f)
// 		{
// 			StartCoroutine(SpawnWave());
// 			countdown = timeBetweenWaves;
// 			return;
// 		}

// 		countdown -= Time.deltaTime;

// 	}

// 	IEnumerator SpawnWave ()
// 	{

// 		Wave wave = waves[waveIndex];

// 		for (int i = 0; i < wave.count; i++)
// 		{
// 			SpawnEnemy(wave.enemy);
// 			yield return new WaitForSeconds(1f / wave.rate);
// 		}
// 		waveIndex++;

// 	}

// 	void SpawnEnemy (Transform enemy)
// 	{
// 		//Destroy(gameObject);
// 		Transform _sp = spawnPoint[ Random.Range (0, spawnPoint.Length)];
// 		Instantiate(enemy, _sp.position, _sp.rotation);
// 		EnemiesAlive++;
// 	}
// }















//     public enum SpawnState {COUNTING};
	
// 	public Transform enemyPrafeb;

// 	//public Wave[] waves;

// 	public Transform[] spawnPoint;

// 	public float timeBetweenWaves = 5f;
// 	private float countdown = 2f;

// 	private int waveIndex = 0;
// 	private SpawnState state = SpawnState.COUNTING;

// 	void Start()
//     {
//          if(spawnPoint.Length==0)
//         {
//             Debug.LogError("No Spawn Points referanced.");
//         }

//         countdown = timeBetweenWaves;
//     }

// 	void Update ()
// 	{
		
// 		if (countdown <= 0f)
// 		{
// 			StartCoroutine(SpawnWave());
// 			countdown = timeBetweenWaves;
// 			//return;
// 		}

// 		countdown -= Time.deltaTime;

// 	}

// 	IEnumerator SpawnWave ()
// 	{
// 		waveIndex++;

// 		for (int i = 0; i < waveIndex; i++)
// 		{
// 			SpawnEnemy();
// 			yield return new WaitForSeconds(0.5f);
// 		}

// 	}

// 	void SpawnEnemy ()
// 	{
// 		//Destroy(gameObject);
// 		Transform _sp = spawnPoint[ Random.Range (0, spawnPoint.Length)];
// 		Instantiate(enemyPrafeb, _sp.position, _sp.rotation);
// 	}
// }