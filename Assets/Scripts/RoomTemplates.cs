using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms; 
    public GameObject bottomClosed;
    public GameObject topClosed;
    public GameObject leftClosed;
    public GameObject rightClosed;

    public GameObject closedRoom;
    
    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    public LevelList levelList = new LevelList();
    public int level = 0;
    public List<Color> floorColor = new List<Color>();

    private void Start(){
        StartCoroutine(ChangeFloorColor());
    }

    IEnumerator ChangeFloorColor(){
        yield return new WaitForSeconds(4 * floorColor.Count);
        int i = 0;
        foreach (var lelevel in levelList.list){
            foreach (var room in lelevel.list){
                try{
                    room.GetComponent<Room>().floorColor.color = floorColor[i];
                }
                catch (Exception e){
                    ;
                }
            }
            i++;
        }
    }

    private void Update(){
        if (waitTime <= 0 && level <= 4){
            Instantiate(boss, levelList.list[level].list[^1].transform.position, Quaternion.identity);
            waitTime = 4f;
            level += 1;
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }

    [System.Serializable]
    public class Level{
        public List<GameObject> list;
    }

    [System.Serializable]
    public class LevelList{
        public List<Level> list;
    }
}

