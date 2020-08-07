﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!bird.IsDead())
        {
            // pindahkan pipa ke sebelah kiri
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if(bird)
        {
            // ambil komponen Collider pada game object
            Collider2D collider = GetComponent<Collider2D>();

            if(collider)
            {
                // matikan collider
                collider.enabled = false;
            }
        }

        // matikan burung
        bird.Dead();
    }
}
