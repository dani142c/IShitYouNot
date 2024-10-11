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
    public AudioClip playerReoad;

    // Upgrades - De er multipliers
    public int points = 5;
    public float speed = 1f;
    public float damage = 1f;
    public float health = 50f; 
    public TextMeshProUGUI healthText;
    public Canvas gameOver;

    public bool isReloading = false;

    public int speedX = 0;
    


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        healthText.text = health.ToString();
    }


 IEnumerator ReloadTimer(float time)
    {
        isReloading = true;
        yield return new WaitForSeconds(time);
        equippedGun.Reload();
        SoundManager.instance.playSound(playerReoad, Player.instance.transform, 1f);
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {


        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(!isReloading){
                StartCoroutine(ReloadTimer(1.5f));
            } else {
                Debug.Log("already reloading");
            }
        }
    }

    public void PlayerUpgradeSpeed(int x)
    {
        this.speed = (float)(0.5 * Math.Sqrt(x) + 1);
        x++;
    }

    public void PlayerUpgradeDamage(float multiplier)
    {
        this.damage += multiplier;
        this.equippedGun.gunDamage = this.damage;
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
