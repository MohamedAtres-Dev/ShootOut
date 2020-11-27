using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singlton<GameManager>
{
    public int numOfEnemies = 3;

    public bool isGameStart;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.onStartGame += HandleGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleGameStart()
    {
        isGameStart = true;
    }
}
