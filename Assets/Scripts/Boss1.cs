using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour{
    public float cooldown;
    public int shotsAmount;
    public GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D playerRB;    
    public float bulletForce = 5f;
    public Animator anim;
    public Rigidbody2D boss;

    private Vector2 direction;

    private void Start(){
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void Activate(){
        Debug.Log("CHUJ");
        StartCoroutine(ShootAndWait());
    }

    private void Update()
    {
        direction = playerRB.position - boss.position;
        animate();
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
    private void animate()
    {
        anim.SetFloat("X", direction.x);
        anim.SetFloat("Y", direction.y);
    }
}
