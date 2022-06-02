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

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }

    private void FixedUpdate(){
        transform.position = Vector2.MoveTowards(transform.position, 
            player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            health -= player.attackDamage;
            if (health <= 0){
                player.enemiesInRoom -= 1;
                if (player.enemiesInRoom == 0){
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentRoom.GetComponent<Room>().OpenDoors();
                }
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Player")){
            player.health -= damage;
            if (player.health <= 0){
                Debug.Log("GAME OVER!");
            }
        }
    }
}
