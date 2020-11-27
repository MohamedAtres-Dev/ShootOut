using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStart)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,  - PlayerInput.rotationY + 180f, transform.localEulerAngles.z);
        }
    }
}
