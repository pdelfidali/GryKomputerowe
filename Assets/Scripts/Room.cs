using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour{
    public bool isClear = false;
    public List<BoxCollider2D> doors;
    private List<Enemy> templates;


    private void Start(){
        templates =  GameObject.FindGameObjectWithTag("Templates").GetComponent<EnemyTemplates>().enemies;
    }

    public void CloseDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = false;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        SpawnEnemies();
    }

    private void SpawnEnemies(){
         int rand =  Random.Range(0, templates.Count);
         Instantiate(templates[rand], transform.position,
             templates[rand].transform.rotation);
    }
}
