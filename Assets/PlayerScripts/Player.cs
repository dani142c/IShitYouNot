using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Gun equippedGun;

    public AudioClip playerDeath;

    // Upgrades - De er multipliers
    public int points = 5;
    public float speed = 1f;
    public float damage = 1f;
    public float health = 50f; 
    public TextMeshProUGUI healthText;
    public Canvas gameOver;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        healthText.text = health.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            equippedGun.Reload();
        }
    }

    public void PlayerUpgradeSpeed(float multiplier)
    {
        this.speed += multiplier;
    }

    public void PlayerUpgradeDamage(float multiplier)
    {
        this.damage += multiplier;
        this.equippedGun.gunDamage *= this.damage;
    }

    public void PlayerUpgradeHealth(float multiplier)
    {
        this.health += multiplier;
    }

    public void PlayerTakeDamage(float dmg){
        health -= dmg;
        healthText.text = health.ToString();

        if(health <= 0){
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        SoundManager.instance.playSound(playerDeath, this.transform, 1f);
        //end game and add sfx
        GameOver();
    }

    public void GameOver()
    {
        WaveManager.IsGamePaused = true;
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
    }
}
