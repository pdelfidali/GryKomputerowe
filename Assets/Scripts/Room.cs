using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour{
    public bool isClear = false;
    public List<BoxCollider2D> doors;
    private List<Enemy> enemies;
    public List<GameObject> spawnPoints;
    public Camera mainCamera;
    public Tilemap floorColor;
    public bool spawnEnemies = true;
    public GameObject boss;

    private void Start(){
        enemies = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>().enemies;
    }

    public void CloseDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = false;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if(spawnEnemies){
            SpawnEnemies();
        }
        else{
            boss.GetComponent<Boss1>().Activate();
        }
    }

    private void SpawnEnemies(){
        ShuffleSpawnPoints();
        int amountOfEnemies = Random.Range(1, 5);
        int i = 0;
        while (i < amountOfEnemies){
            int rand = Random.Range(0, enemies.Count);
            Instantiate(enemies[rand], spawnPoints[i].transform.position, enemies[rand].transform.rotation);
            i++;
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().enemiesInRoom = amountOfEnemies;
    }

    public void OpenDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = true;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        isClear = true;
    }

    private void ShuffleSpawnPoints(){
        for (int i = 0; i < spawnPoints.Count; i++){
            var temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Count);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }
    }
}
