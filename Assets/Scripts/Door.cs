using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour{
    public GameObject room;

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            if (!room.GetComponent<Room>().isClear){
                room.GetComponent<Room>().CloseDoors();
            }
        }
    }
}
