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

    public LevelList levelList = new LevelList();
    public int level = 0;
    public List<Color> floorColor = new List<Color>();

    public List<int> levelsWithBoss;

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
                Debug.Log(level);
                GameObject lastTop = LastTop(levelList.list[level].list);
                lastTop.GetComponent<Room>().boss = Instantiate(boss, lastTop.transform.position, Quaternion.identity);
                lastTop.GetComponent<Room>().spawnEnemies = false;
            }

            waitTime = 4f;
            level += 1;
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }

    private GameObject LastTop(List<GameObject> _level){
        for (int i = _level.Count - 1; i > 0; i--){
            if (_level[i].name is "B(Clone)" or "BL(Clone)" or "BR(Clone)"){
                return _level[i];
            }
        }
        return null;
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

