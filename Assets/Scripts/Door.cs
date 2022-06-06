using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour{
    public GameObject room;

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            double TOLERANCE = 5;
            var position = other.transform.position;
            var position1 = room.transform.position;
            if (!room.GetComponent<Room>().isClear && 
                Math.Abs(position.x - position1.x) < TOLERANCE &&
                Math.Abs(position.y - position1.y) < TOLERANCE){
                room.GetComponent<Room>().CloseDoors();
            }
        }
    }
}
