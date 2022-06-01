using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour{
    public bool isClear = false;
    public List<BoxCollider2D> doors;

    public void CloseDoors(){
        foreach (var boxCollider2D in doors){
            boxCollider2D.isTrigger = false;
            boxCollider2D.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
