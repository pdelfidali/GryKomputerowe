using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public float velocity;
    public Rigidbody2D rb;

    private void Start(){
        rb.AddForce(transform.forward * velocity);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Walls")){
            Destroy(gameObject);
        }
    }
}
