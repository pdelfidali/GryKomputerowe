using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKilled : MonoBehaviour{
    public int bossesNeeded;
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            if (other.gameObject.GetComponent<PlayerShooting>().bossesKilled >= bossesNeeded){
                Destroy(gameObject);
            }
        }
    }
}
