using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private float upVelocity = 2f;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.up * upVelocity;
        Destroy(gameObject,5f);
    }

    void Update()
    {
        
    }
}
