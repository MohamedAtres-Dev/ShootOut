using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singlton<LevelManager>
{
    public int numOfEnemies;

    //I just used fixed points for spawining but i can make a better solution(e.g. Data for levels) 
    public List<Transform> spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        UIManager.onStartGame += HandleStartGame;
        UIManager.onLoadNextLevel += LoadNextLevel;
        numOfEnemies = 1;
    }

    void HandleStartGame()
    {
        

        SpawnWave();

    }

    void LoadNextLevel()
    {
        numOfEnemies++;
        if (numOfEnemies > 2)
            numOfEnemies = 2;
        Debug.Log("Num of Enemies" + numOfEnemies);
        SpawnWave();
    }

    void SpawnWave()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            SpawnEnemy();
           
        }
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, 4);

        GameObject enemy = PoolManager.Instance.GetPooledObject("Enemy");
        enemy.transform.position = spawnPoints[rand].position;
        enemy.transform.rotation = spawnPoints[rand].rotation;
        enemy.SetActive(true);
    }

    void SpawnReflector()
    {
        int rand = Random.Range(0, 5);

        GameObject reflector = PoolManager.Instance.GetPooledObject("Reflector");
        reflector.transform.position = spawnPoints[rand].position;
        reflector.transform.rotation = spawnPoints[rand].rotation;
        reflector.SetActive(true);
    }


}
