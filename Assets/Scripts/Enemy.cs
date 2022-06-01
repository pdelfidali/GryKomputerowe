using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float health;
    public PlayerShooting player;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bullet")){
            health -= player.attackDamage;
            if (health <= 0){
                player.enemiesInRoom -= 1;
                if (player.enemiesInRoom == 0){
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentRoom.GetComponent<Room>().OpenDoors();
                }
                Destroy(gameObject);
            }
        }
    }
}
