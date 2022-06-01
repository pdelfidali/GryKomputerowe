using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour{
    public GameObject room;

    private void OnTriggerEnter(Collider other){
        print(other.name);
        if (other.CompareTag("Player")){
            Debug.Log(room.transform.position);
            Camera.main.transform.position = room.transform.position;
        }
    }
}
