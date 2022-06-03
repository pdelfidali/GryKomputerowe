using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float health;
    public PlayerShooting player;
    public float moveSpeed = 5f;
    public float damage = 1f;
    public bool canMove = true;
    public Rigidbody2D rb;
    public Rigidbody2D playerRB;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        if(canMove){
            transform.position = Vector2.MoveTowards(transform.position,
                player.transform.position, moveSpeed * Time.deltaTime);
        }

        Vector2 lookDir = playerRB.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;    
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            health -= player.attackDamage;
            if (health <= 0){
                player.enemiesInRoom -= 1;
                if (player.enemiesInRoom == 0){
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentRoom.GetComponent<Room>().OpenDoors();
                    player.SpawnLoot();
                }
                Destroy(gameObject);
            }
        }

    }
}
