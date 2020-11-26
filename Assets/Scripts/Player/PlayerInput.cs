using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float inputX;

    private float minRotation = -90f;
    private float maxRotation = 90f;

    private float rotationY = 0f;
    private float senstivityY = 2f;

    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update

    private bool isGameStart;

    private void Awake()
    {
        isGameStart = false;
    }

    private void Start()
    {
        UIManager.onStartGame += HandleStartGame;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
            RotatePlayer();
    }

    void RotatePlayer()
    {
        rotationY += Input.GetAxis("Horizontal") * senstivityY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
    }

    void HandleStartGame()
    {
        isGameStart = true;
    }
}
