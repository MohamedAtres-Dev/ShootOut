using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    private RaycastReflection reflect;

    public static event Action onFire;
    private void Awake()
    {
        reflect = GetComponent<RaycastReflection>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (reflect.isEnemy == true)
            {
                reflect.lineRenderer.enabled = false;
                Debug.Log("Enemy has been Shooted");

                onFire();
                //TODO: make muzzle effect ans sound
            }
        }
    }
}
