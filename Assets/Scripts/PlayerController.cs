using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;


    public GameObject currentRoom;
    
    
    private Vector2 movement;
    private Vector2 mousePos;
    
    
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        animate();
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.deltaTime));

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
        rb.rotation = 0;
    }
    
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Doors")){
            currentRoom = other.GetComponent<Door>().room;
            Vector3 position = currentRoom.transform.position;
            position.z = -10f;
            cam.transform.position = position;
        }
    }

    private void animate()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
