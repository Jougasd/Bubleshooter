using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    private Rigidbody2D rb;

    public enum BulletType
    {
        Blue,Green,Yellow,Red
    }
    public BulletType bulletType;

    private void start()
    {
        rb= GetComponent<Rigidbody2D>();

        SetStraightVelocity();
    }
    
    private void IntializeBulletStats()
    {
      
    }

    // Update is called once per frame
    private void SetStraightVelocity()
    {
        rb.velocity=transform.right*normalBulletSpeed;  
    }
}
