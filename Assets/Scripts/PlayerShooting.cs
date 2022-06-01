using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour{
    
    private Quaternion direction;
    public float attackSpeed = 0.25f;
    private float timeFromLastAttack;
    public GameObject bullet;
    private Vector3 positionToSpawn;
    void FixedUpdate(){
        positionToSpawn = transform.position;
        timeFromLastAttack += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            direction = Quaternion.Euler(0, 0, 180);
            positionToSpawn.x -= 0.7f;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)){
            direction = Quaternion.Euler(0, 0, 90);
            positionToSpawn.y += 0.7f;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)){
            direction = Quaternion.Euler(0, 0, 0);
            positionToSpawn.x += 0.7f;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)){
            direction = Quaternion.Euler(0, 0, -90);
            positionToSpawn.y -= 0.7f;
        } else {return;}

        if (timeFromLastAttack > 1 / attackSpeed){
            Instantiate(bullet, transform.position, direction);
            timeFromLastAttack = 0;
        }
    }
}
