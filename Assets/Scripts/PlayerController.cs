using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    
    
    private Vector2 movement;
    private Vector2 mousePos;
    
    
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Doors")){
            Debug.Log(other.GetComponent<Door>().room.transform.position);
            Vector3 position = other.GetComponent<Door>().room.transform.position;
            position.z = -10f;
            cam.transform.position = position;
        }
    }
}
