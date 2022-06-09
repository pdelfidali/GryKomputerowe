using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    public float bulletForce = 5f;
    public float attackSpeed = 2f;
    private float timeFromLastAttack = 0f;
    private Rigidbody2D playerRB;
    private Rigidbody2D rb;
    private Vector2 direction;
    
    private void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update(){
        if (timeFromLastAttack > 1/attackSpeed){
            Shoot();
        }
        timeFromLastAttack += Time.deltaTime;
        direction = playerRB.position - rb.position;
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
        timeFromLastAttack = 0;
    }
}
