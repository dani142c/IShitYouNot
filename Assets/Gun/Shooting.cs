using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        if (player.equippedGun.currentAmmo > 0)
        {
            reloadHint.gameObject.SetActive(false);
        }
        else
        {
            reloadHint.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0)) // "Fire1" should be replaced with 0 to indicate the left mouse button
        {
            if (player.equippedGun.currentAmmo > 0)
            {
                SoundManager.instance.playSound(shootSFX, player.transform, 1f);
                player.equippedGun.Shoot();
            }
        }
    }

}
