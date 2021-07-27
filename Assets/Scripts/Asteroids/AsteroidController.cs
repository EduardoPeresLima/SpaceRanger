using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    private const float minVelocity = 1f;
    private const float maxVelocity = 4f;
    private const float minYToDie = -5f;
    private Rigidbody2D rig;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        float velocity = Random.Range(minVelocity, maxVelocity);
        rig.velocity = velocity * Vector2.down;
    }
    void Update()
    {
        VerifyDeathByOffBounds();
    }

    void VerifyDeathByOffBounds()
    {
        if (transform.position.y < minYToDie) Death();
    }

    public void Death()
    {
        //Explosion
        Destroy(gameObject);
    }
}
