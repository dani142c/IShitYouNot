using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gunPivot;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // "Fire1" should be replaced with 0 to indicate the left mouse button
        {
            player.equippedGun.Shoot();
        }
    }    
}
