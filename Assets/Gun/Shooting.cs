using System.Collections;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public AudioClip shootSFX;
    public Transform gunPivot;
    public GameObject bulletPrefab;
    public TextMeshProUGUI reloadHint;

    public float bulletForce = 20f;

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();

        shootSFX = Resources.Load<AudioClip>("sfx/PlayerSFX/shoot");
    }

    void Update()
    {
        // Completely block shooting logic when the game is paused
        if (WaveManager.IsGamePaused)
        {
            reloadHint.gameObject.SetActive(false);  // Hide the reload hint during pause
            return;  // Stop execution of the rest of the Update function
        }

        // Only run shooting and reload logic when the game is not paused
        if (player.equippedGun.currentAmmo > 0)
        {
            reloadHint.gameObject.SetActive(false);
        }
        else
        {
            reloadHint.gameObject.SetActive(true);
        }

        // Shooting logic (only if the game is not paused)
        if (Input.GetMouseButtonDown(0))  // "Fire1" replaced with 0 to indicate the left mouse button
        {
            if (player.equippedGun.currentAmmo > 0)
            {
                SoundManager.instance.playSound(shootSFX, player.transform, 1f);
                player.equippedGun.Shoot();
            }
        }
    }
}
