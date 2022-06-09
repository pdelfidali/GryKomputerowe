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
    
    private void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update(){
        if (timeFromLastAttack > 1/attackSpeed){
            Shoot();
        }
        timeFromLastAttack += Time.deltaTime;
    }

    private void FixedUpdate(){
        
        Vector2 lookDir = playerRB.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        timeFromLastAttack = 0;
    }
}
