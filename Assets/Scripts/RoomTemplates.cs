using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject boss2;

    public LevelList levelList = new LevelList();
    public int level = 0;
    public List<Color> floorColor = new List<Color>();

    public List<int> levelsWithBoss;
    public int levelWithBoss2;

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
        if (waitTime <= 0 && level <= 14){
            if (levelsWithBoss.Contains(level)){
                GameObject lastTop = levelList.list[level].list[^1];
                lastTop.GetComponent<Room>().boss = Instantiate(boss, lastTop.transform.position, Quaternion.identity);
                lastTop.GetComponent<Room>().spawnEnemies = false;
                lastTop.GetComponent<Room>().boss.transform.parent = lastTop.transform;
            }

            if (level == levelWithBoss2){
                GameObject lastTop = levelList.list[level].list[^1];
                lastTop.GetComponent<Room>().boss = Instantiate(boss2, lastTop.transform.position, Quaternion.identity);
                lastTop.GetComponent<Room>().spawnEnemies = false;
                lastTop.GetComponent<Room>().boss.transform.parent = lastTop.transform;
            }

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

