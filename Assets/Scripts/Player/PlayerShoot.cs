using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{

    private RaycastReflection reflect;

    /// <summary>
    /// Event for game Success 
    /// </summary>
    public delegate void GameSuccess();
    public static event GameSuccess onGameSuccess;
    private void Awake()
    {
        reflect = GetComponent<RaycastReflection>();
    }


    // Update is called once per frame
    void Update()
    {
        //Get this from player Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(reflect.hit.collider != null)
            {
                if (reflect.hit.collider.CompareTag("Enemy"))
                {
                    reflect.hit.collider.gameObject.SetActive(false);

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
 
        }
    }
}
