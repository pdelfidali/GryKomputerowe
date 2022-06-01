using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    
    
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other){
        print(other.name);
        if (other.CompareTag("Doors")){
            Debug.Log(other.GetComponent<Door>().room.transform.position);
            Vector3 position = other.GetComponent<Door>().room.transform.position;
            position.z = -10f;
            Camera.main.transform.position = position;
        }
    }
}
