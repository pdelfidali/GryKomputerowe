using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class Boss2 : MonoBehaviour{
    public Rigidbody2D rb;
    public float walkingTime;
    public float chargingTime;
    public float speed;
    private Rigidbody2D playerRB;
    private int xMod = 1;
    private int yMod = 1;
    public AudioSource source;
    public AudioClip boss2music;

    private void Start(){
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        source = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    public void Activate(){
        source.clip = boss2music;
        source.Play();
       StartCoroutine(Run());
    }

    IEnumerator Run(){
        yield return new WaitForSeconds(chargingTime);
        rb.velocity = (playerRB.position - rb.position)*speed;
        StartCoroutine(Run());
    }

    private void OnCollisionEnter2D(Collision2D other){
        yMod = yMod * -1;
        xMod = xMod * -1;
    }
    
    
    private void OnDestroy(){
        playerRB.gameObject.GetComponent<PlayerShooting>().bossesKilled += 1;
    }
}
