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
    public GameObject deadGUI;
    public GameObject playerGUIGO;
    public AudioSource audioSource;

    private void Start(){
        Time.timeScale = 1;
        timeFromLastAttack = 1 / attackSpeed;
        playerGUIGO.SetActive(true);
        playerUI.UpdateUI();
    }

    private void Update(){
        timeFromLastAttack += Time.deltaTime;
    }

    public void Shoot(Vector2 mousePosition){
        if(timeFromLastAttack > 1/attackSpeed){
            audioSource.Play();
            var position = firePoint.position;
            GameObject bullet = Instantiate(bulletPrefab, position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((mousePosition - (Vector2) position).normalized * bulletForce, ForceMode2D.Impulse);
            timeFromLastAttack = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("EnemyBullet")){
            health -= other.gameObject.GetComponent<Bullet>().attackDamage;
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

        if (health <= 0){
            Time.timeScale = 0;
            deadGUI.SetActive(true);
            playerGUIGO.SetActive(false);
        }
        
        playerUI.UpdateUI();
    }

    public void SpawnLoot(){
        int rand = Random.Range(0, lootPrefabs.Count);
        Instantiate(lootPrefabs[rand], playerController.currentRoom.transform.position, Quaternion.identity);
    }
}
