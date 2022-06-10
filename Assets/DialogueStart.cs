using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour{
    public DialogPierdolony dialogue;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }
}
