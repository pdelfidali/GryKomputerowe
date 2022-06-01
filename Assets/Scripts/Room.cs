using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour{
    public bool isClear = false;
    public List<BoxCollider2D> doors;
    private List<Enemy> enemies;

    private void Start(){
        enemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>().enemies;
    }

    public void CloseDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = false;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        SpawnEnemies();
    }

    private void SpawnEnemies(){
        int rand = Random.Range(0, enemies.Count);
        Instantiate(enemies[rand], transform.position, enemies[rand].transform.rotation);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().enemiesInRoom = 1;
    }

    public void OpenDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = true;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        }

        isClear = true;
    }
}
