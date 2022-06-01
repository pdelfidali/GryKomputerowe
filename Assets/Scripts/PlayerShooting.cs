using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;
    public float attackSpeed = 2f;
    private float timeFromLastAttack = 0f;

    private void Start(){
        timeFromLastAttack = 1 / attackSpeed;
    }

    private void Update(){
        if (Input.GetButtonDown("Fire1") && timeFromLastAttack > 1/attackSpeed){
            Shoot();
        }
        timeFromLastAttack += Time.deltaTime;
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        timeFromLastAttack = 0;
    }
}
