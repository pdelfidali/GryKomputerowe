using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;
    public float attackSpeed = 2f;
    public float attackDamage = 2f;
    private float timeFromLastAttack = 0f;
    public int enemiesInRoom;
    public float health = 10f;
    public PlayerUI playerUI;

    private void Start(){
        timeFromLastAttack = 1 / attackSpeed;
        playerUI.UpdateUI();
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

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("EnemyBullet")){
            health -= other.gameObject.GetComponent<Bullet>().attackDamage;
            playerUI.UpdateUI();
        }

        if (other.gameObject.CompareTag("Enemy")){
            health -= other.gameObject.GetComponent<Enemy>().damage;
        }
        
        playerUI.UpdateUI();
    }
}
