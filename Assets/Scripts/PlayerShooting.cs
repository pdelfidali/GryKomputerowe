using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;
    public float attackSpeed = 2f;
    public float attackDamage = 2f;
    private float timeFromLastAttack = 0f;
    public int enemiesInRoom;
    public float health = 10f;
    public float maxHealth = 10f;
    public PlayerUI playerUI;
    public List<GameObject> lootPrefabs;
    public PlayerController playerController;

    private void Start(){
        timeFromLastAttack = 1 / attackSpeed;
        playerUI.UpdateUI();
    }

    private void Update(){
        timeFromLastAttack += Time.deltaTime;
    }

    public void Shoot(){
        if(timeFromLastAttack > 1/attackSpeed){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            timeFromLastAttack = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("EnemyBullet")){
            health -= other.gameObject.GetComponent<Bullet>().attackDamage;
            playerUI.UpdateUI();
        }

        if (other.gameObject.CompareTag("Enemy")){
            health -= other.gameObject.GetComponent<Enemy>().damage;
        }

        if (other.gameObject.CompareTag("Loot")){
            Loot loot = other.gameObject.GetComponent<Loot>();
            attackSpeed += loot.attackSpeedModificator;
            attackDamage += loot.attackDamageModificator;
            health += loot.healthModificator;
            maxHealth += loot.maxHealthModificator;
            Destroy(other.gameObject);
        }
        
        playerUI.UpdateUI();
    }

    public void SpawnLoot(){
        int rand = Random.Range(0, lootPrefabs.Count);
        Instantiate(lootPrefabs[rand], playerController.currentRoom.transform.position, Quaternion.identity);
    }
}
