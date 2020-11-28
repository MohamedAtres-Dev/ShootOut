using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singlton<GameManager>
{
    public GameObject victoryFx;
    public Transform victoryPos;
    public AudioClip victorySFX;

    public int numOfEnemies = 1;

    public bool isGameStart;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.onStartGame += HandleGameStart;
        PlayerShoot.onGameSuccess += HandleGameSuccess;
        EnemyShoot.onEnemyFire += HandleGameOver;
    }


    void HandleGameSuccess()
    {

        AudioManager.Instance.PlaySound(victorySFX);

        Instantiate(victoryFx, victoryPos.position, Quaternion.identity);
    }

    void HandleGameStart()
    {
        isGameStart = true;
    }

    void HandleGameOver()
    {
        isGameStart = false;
    }
}
