using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PlayerShoot.onFire += HandleInteract;
    }


    void HandleInteract()
    {
        Debug.Log("Enemy Die");

        gameObject.SetActive(false);
        //TODO: make an effect
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
