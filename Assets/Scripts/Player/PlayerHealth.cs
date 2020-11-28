using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject deathFx;
    
    /// <summary>
    /// Event for game Success 
    /// </summary>
    public delegate void GameOver();
    public static event GameOver onGameOver;
    // Start is called before the first frame update
    void Start()
    {
        EnemyShoot.onEnemyFire += HandlePlayerHealth;
    }

    void HandlePlayerHealth()
    {
        Debug.Log("Game Lose");
        //gameObject.SetActive(false);
        onGameOver?.Invoke();

        Instantiate(deathFx, transform.position, Quaternion.identity);
    }
}
