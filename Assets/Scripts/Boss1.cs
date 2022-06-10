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
    public GameObject klapa;
    public GameObject klapa2;
    private Vector2 direction;
    public Sprite otwartaKlapa;
    public Rigidbody2D rb;

    private void Start(){
        klapa = GameObject.FindGameObjectWithTag("Klapa");        
        klapa2 = GameObject.FindGameObjectWithTag("Klapa2");
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
        if(rb){
            if (rb.velocity.x != 0 || rb.velocity.y != 0){
                anim.SetFloat("X", rb.velocity.x);
                anim.SetFloat("Y", rb.velocity.y);
                anim.SetBool("isMoving", true);
            }
            else{
                anim.SetBool("isMoving", false);
            }
        }
    }

    private void OnDestroy(){
        playerRB.gameObject.GetComponent<PlayerShooting>().bossesKilled += 1;
        if (playerRB.gameObject.GetComponent<PlayerShooting>().bossesKilled >= 1){
            klapa.GetComponent<SpriteRenderer>().sprite = otwartaKlapa;
        }if (playerRB.gameObject.GetComponent<PlayerShooting>().bossesKilled >= 2){
            klapa2.GetComponent<SpriteRenderer>().sprite = otwartaKlapa;
        }
    }
}
