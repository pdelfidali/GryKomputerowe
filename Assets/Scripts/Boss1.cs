using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour{
    public float cooldown;
    public int shotsAmount;
    public GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D playerRB;    
    public float bulletForce = 5f;

    private void Start(){
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void Activate(){
        Debug.Log("CHUJ");
        StartCoroutine(ShootAndWait());
    }

    IEnumerator ShootAndWait(){
        yield return new WaitForSeconds(cooldown);
        Debug.Log("CHUJ");
        for (int i = 0; i < shotsAmount; i++){
            yield return new WaitForSeconds(0.1f);
            GameObject bullet = Instantiate(bulletPrefab,transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((playerRB.position - rb.position).normalized * bulletForce, ForceMode2D.Impulse);
        }
        StartCoroutine(ShootAndWait());
    }
}
