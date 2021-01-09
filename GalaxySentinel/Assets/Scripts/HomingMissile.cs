using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 270f;
    [SerializeField] float speed = 10f;

    Rigidbody2D rigidBody;
    Transform target;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;

            Vector2 direction = (Vector2)target.position - rigidBody.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rigidBody.angularVelocity = -rotateAmount * rotateSpeed;
            rigidBody.velocity = transform.up * speed;

        }
        catch (Exception)
        {
            rigidBody.velocity = new Vector2(0, speed);
        }
    }
}
