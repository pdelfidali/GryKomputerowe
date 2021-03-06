using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour{
    public TextMeshProUGUI attackSpeed;
    public TextMeshProUGUI attackDamage;
    public TextMeshProUGUI level;
    public Slider health;
    public PlayerShooting player;

    public void UpdateUI(){
        attackSpeed.text = player.attackSpeed.ToString();
        attackDamage.text = player.attackDamage.ToString();
        health.value = player.health;
        health.maxValue = player.maxHealth;
        level.text = player.level.ToString();
    }
}
