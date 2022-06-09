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

    public float waitTime = 3f;

    public float delay;

    public int maxRooms = 8;

    private void Start(){
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f + delay);
        Destroy(gameObject, waitTime + delay);
    }

    private void Spawn(){
        if (!spawned){
            if (templates.levelList.list[templates.level].list.Count < maxRooms){
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
            }
            else{
                switch (openingDirection){
                    case OpeningDirection.Top:
                        Instantiate(templates.topClosed, transform.position, templates.topClosed.transform.rotation);
                        break;
                    case OpeningDirection.Bottom:
                        Instantiate(templates.bottomClosed, transform.position, templates.bottomClosed.transform.rotation);
                        break;
                    case OpeningDirection.Left:
                        Instantiate(templates.leftClosed, transform.position, templates.leftClosed.transform.rotation);
                        break;
                    case OpeningDirection.Right:
                        Instantiate(templates.rightClosed, transform.position, templates.rightClosed.transform.rotation);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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
                   ;
                }
            }
        } 
        spawned = true;
    }
}
