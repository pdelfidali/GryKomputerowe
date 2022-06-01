using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour{
    public enum OpeningDirection{
        Top,
        Bottom,
        Left,
        Right
    }

    public OpeningDirection openingDirection;

    private RoomTemplates templates;
    private int rand;
    private bool spawned;

    public float waitTime = 4f;

    private void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
        Destroy(gameObject, waitTime);
    }

    private void Spawn(){
        if (!spawned){
            switch (openingDirection){
                case OpeningDirection.Top:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position,
                        templates.topRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Bottom:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position,
                        templates.bottomRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Left:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position,
                        templates.leftRooms[rand].transform.rotation);
                    break;
                case OpeningDirection.Right:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position,
                        templates.rightRooms[rand].transform.rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("SpawnPoint")){
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned){
                try{
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    throw;
                }
            }
        } 
        spawned = true;
    }
}
