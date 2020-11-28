using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private RaycastReflection reflect;

    private bool isTapped;

    public AudioClip shootSFX;
    
    /// <summary>
    /// Event for game Success 
    /// </summary>
    public delegate void EnemyFire();
    public static event EnemyFire onEnemyFire;

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
        if (isTapped)
        {
            if(reflect.hit.collider != null)
            {
                if (reflect.hit.collider.CompareTag("Player") == true)
                {
                    reflect.lineRenderer.enabled = false;
                    Debug.Log("Player has been Shooted");

                    onEnemyFire?.Invoke();
                    AudioManager.Instance.PlaySound(shootSFX);

                    //TODO: make muzzle effect ans sound
                }
            }

            isTapped = false;
        }
    }

    void HandleSingleTap()
    {
        isTapped = true;
    }
}
