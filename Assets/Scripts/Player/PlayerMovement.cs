using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float minRotation = -90f;
    private float maxRotation = 90f;

    [HideInInspector] public static float rotationY = 0f;
    private float senstivityY = 2f;

    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isGameStart)
            RotatePlayer();
    }

    void RotatePlayer()
    {
        //rotationY += Input.GetAxis("Horizontal") * senstivityY;
        //rotationY = Mathf.Clamp(rotationY, minRotation, maxRotation);
        rotationY = SwipeManager.swipeDirectionX;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY * Time.smoothDeltaTime , transform.localEulerAngles.z);
    }
}
