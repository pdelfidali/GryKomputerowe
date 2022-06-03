using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour{
    public TextMeshProUGUI attackSpeed;
    public TextMeshProUGUI attackDamage;
    public Slider health;
    public PlayerShooting player;

    public void UpdateUI(){
        attackSpeed.text = player.attackSpeed.ToString();
        attackDamage.text = player.attackDamage.ToString();
        health.value = player.health;
    }
}
