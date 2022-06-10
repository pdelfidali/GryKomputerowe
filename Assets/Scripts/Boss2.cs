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
    public AudioSource source;
    private AudioSource background;
    public AudioClip boss2music;

    private void Start(){
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        source = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        background = GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<AudioSource>();
        StartCoroutine(Run());
    }

    public void Activate(){
        background.clip = boss2music;
        background.Play();
       StartCoroutine(Run());
    }

    IEnumerator Run(){
        yield return new WaitForSeconds(chargingTime);
        rb.velocity = (playerRB.position - rb.position)*speed;
        StartCoroutine(Run());
    }
    
    
    
    private void OnDestroy(){
        playerRB.gameObject.GetComponent<PlayerShooting>().bossesKilled += 1;
        background.Play();
    }
    
    
}
