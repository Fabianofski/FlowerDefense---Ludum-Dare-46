using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> EnemyWave;
    public Transform[] Spawnpoints;
    public float timebtwSpawn;
    public bool WaveStarted = true;
    public int numberZ;
    public int maxnumberZ;
    public int enemiesAlive;
    public int enemiesTotal;
    public float Multiplier;
    public bool isRunning;

    
    void Awake()
    {
        Time.timeScale = 1;
        numberZ = 1;
        StartCoroutine(StartWave());
    }

    void Update()
    {
        if(!isRunning && WaveStarted)
        {
            StartCoroutine(StartWave());
        }

        if (numberZ > maxnumberZ)
            numberZ = maxnumberZ;
        else
            numberZ = 1 + Mathf.RoundToInt((enemiesTotal - enemiesAlive) * Multiplier);
    }

    // Update is called once per frame
    public IEnumerator StartWave()
    {
        isRunning = true;
        if (enemiesAlive > 0 && WaveStarted)
        { 
            for (int i = 0; i < numberZ; i++)
            {
                if (EnemyWave.Count > 0)
                {               
                Instantiate(EnemyWave[0], Spawnpoints[Random.Range(0, Spawnpoints.Length)].position, Quaternion.identity);
                EnemyWave.RemoveAt(0);
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
        yield return new WaitForSeconds(timebtwSpawn);

        isRunning = false;
        if(WaveStarted && GetComponent<Spawner>().enabled)
         StartCoroutine(StartWave());
    }
}
