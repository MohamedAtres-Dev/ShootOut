using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    #region Fields
    private RaycastReflection reflect;

    private bool isTapped;

    public AudioClip shootSFX;
    public AudioClip enemyDieSFX;

    public GameObject enemyDieFX;

    /// <summary>
    /// Event for game Success 
    /// </summary>
    public delegate void GameSuccess();
    public static event GameSuccess onGameSuccess;

    public delegate void EnemyShooted();
    public static event EnemyShooted onEnemyShooted;
    #endregion

    private void Awake()
    {
        reflect = GetComponent<RaycastReflection>();
    }


    private void Start()
    {
        SwipeManager.OnSingleTap += HandleSingleTap;
    }

   
    // Update is called once per frame
    void Update()
    {
        WeaponShoot();

    }
    void HandleSingleTap()
    {
        isTapped = true;
    }
    
    void WeaponShoot()
    {
        //Get this from player Input
        if (isTapped)
        {
            if (reflect.hit.collider != null)
            {
                if (reflect.hit.collider.CompareTag("Enemy"))
                {

                    HandleEnemyShooted(reflect.hit.collider.gameObject);

                    AudioManager.Instance.PlaySound(shootSFX);

                    GameManager.Instance.numOfEnemies--;

                    if (GameManager.Instance.numOfEnemies == 0)
                    {
                        reflect.lineRenderer.enabled = false;
                        onGameSuccess?.Invoke();
                    }


                    //TODO : get refrenco of num of enemy num before disable line renderer

                    Debug.Log("Enemy has been Shooted");

                    //TODO: make muzzle effect ans sound
                }
            }

            isTapped = false;

        }
    }

    void HandleEnemyShooted(GameObject enemy)
    {
        enemy.SetActive(false);

        AudioManager.Instance.PlaySound(enemyDieSFX);

        Instantiate(enemyDieFX, enemy.transform.position, Quaternion.identity);
    }
}
