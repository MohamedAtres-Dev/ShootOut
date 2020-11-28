using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject deathFx;
    public AudioClip deathSFX;

    // Start is called before the first frame update
    void Start()
    {
        PlayerShoot.onEnemyShooted += HandleHit;
    }

    void HandleHit()
    {

    }

}
