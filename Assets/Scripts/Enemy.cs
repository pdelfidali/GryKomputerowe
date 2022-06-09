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
    private Rigidbody2D playerRB;
    public Animator anim;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        if(canMove){
            rb.velocity = (playerRB.position - rb.position).normalized * moveSpeed;
        }
    }

    private void Update()
    {
        if (anim){
            animate();
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            health -= player.attackDamage;
            if (health <= 0){
                player.enemiesInRoom -= 1;
                if (player.enemiesInRoom <= 0){
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentRoom.GetComponent<Room>().OpenDoors();
                    player.SpawnLoot();
                }
                Destroy(gameObject);
            }
        }

    }

    private void animate()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetFloat("X", rb.velocity.x);
            anim.SetFloat("Y", rb.velocity.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
