using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private const float maxYToDie = 15f;
    private const float upVelocity = 2f;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.up * upVelocity;
        Destroy(gameObject,5f);
    }

    void Update()
    {
        VerifyDeath();
    }

    void VerifyDeath()
    {
        if (transform.position.y > maxYToDie) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            other.GetComponent<AsteroidController>().Death();
            Death();
        }
    }

    void Death()
    {
        //Explosion
        Destroy(gameObject);
    }
}
