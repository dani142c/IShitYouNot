using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blicky : Gun
{
    // These will now override the properties in the parent Gun class
    public override int maxAmmo { get; set; } = 10;
    public override int currentAmmo { get; set; } = 10;

    public override void Shoot()
    {
        if (this.currentAmmo <= 0)
        {
            Debug.Log("Out of ammo");
            return;
        }

        float offsetDistance = 1.25f;
        Vector3 spawnPosition = gunPivot.position + (-gunPivot.up * offsetDistance);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, gunPivot.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-gunPivot.up * bulletForce, ForceMode2D.Impulse);
        DecreaseAmmo(1);
    }
}
