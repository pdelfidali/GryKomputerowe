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

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    public LevelList levelList = new LevelList();
    public int level = 0;

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

