using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goUpstairs : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public int bossesNeeded = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && bossesNeeded <= player.GetComponent<PlayerShooting>().bossesKilled)
        {
            player.transform.position += Vector3.right * 1006 + Vector3.down * 5;
            cam.transform.position += Vector3.right * 1000;
            other.gameObject.GetComponent<PlayerShooting>().level += 1;
            player.GetComponent<PlayerUI>().UpdateUI();
        }
    }
}
