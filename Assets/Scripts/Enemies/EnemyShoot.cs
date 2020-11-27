using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private RaycastReflection reflect;
    /// <summary>
    /// Event for game Success 
    /// </summary>
    public delegate void EnemyFire();
    public static event EnemyFire onEnemyFire;

    private void Awake()
    {
        reflect = GetComponent<RaycastReflection>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(reflect.hit.collider != null)
            {
                if (reflect.hit.collider.CompareTag("Player") == true)
                {
                    reflect.lineRenderer.enabled = false;
                    Debug.Log("Player has been Shooted");

                    onEnemyFire?.Invoke();
                    //TODO: make muzzle effect ans sound
                }
            }
 
            
        }
    }
}
