using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Update()
    {
        pointsText.text = ("Points: " + Player.instance.points);
    }

    public void UpgradeSpeed()
    {
        if (Player.instance.points >= 1)
        {
            Player.instance.PlayerUpgradeSpeed(Player.instance.speedX);
            Player.instance.points -= 1;
        }
        Debug.Log("Speed upgraded - points: " + Player.instance.points);
    }

    public void UpgradeDamage()
    {
        if (Player.instance.points >= 1)
        {
            Player.instance.PlayerUpgradeDamage(0.15f);
            Player.instance.points -= 1;
        }
        Debug.Log("Damage upgraded");
    }

    public void UpgradeHealth()
    {
        if (Player.instance.points >= 1)
        {
            Player.instance.PlayerUpgradeHealth(0.25f);
            Player.instance.points -= 1;
        }
        Debug.Log("Health upgraded");
    }
}
