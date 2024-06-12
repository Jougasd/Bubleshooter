using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAimAndShoot: MonoBehaviour
{
    [SerializeField] private GameObject launcher;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;
    private Vector2 worldPosition;
    private Vector2 direction;

    private float rotationSpeed = 50.0f;
    private float maxLeftAngle = 85.0f;
    private float maxRightAngle = 275.0f;



    private void Update()
    {
        HandleLauncherRotation();
        HandleLauncherShooting();
    }

    private void HandleLauncherRotation()
    
        {
            float mouseAxisX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.back * mouseAxisX * this.rotationSpeed * Time.deltaTime);
            if (transform.eulerAngles.z > this.maxLeftAngle && transform.eulerAngles.z < 180.0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxLeftAngle);
            }
            if (transform.eulerAngles.z < this.maxRightAngle && transform.eulerAngles.z > 180.0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRightAngle);
            }
        }
    
    private void HandleLauncherShooting()
    {
     if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, launcher.transform.rotation);
        }
    }
}
