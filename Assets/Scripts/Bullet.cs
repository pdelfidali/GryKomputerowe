using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public Rigidbody2D rb;
    public float attackDamage = 2f;
    
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Walls") || other.gameObject.CompareTag("Doors") 
                                                 || other.gameObject.CompareTag("Bullet")
                                                 || other.gameObject.CompareTag("EnemyBullet")){
            Destroy(gameObject);
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D other){
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
}
