using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public Rigidbody2D rb;
    public float attackDamage = 2f;

    private void Start(){
        StartCoroutine(DeleteAfter2());
    }

    private IEnumerator DeleteAfter2(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D other){
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
}
