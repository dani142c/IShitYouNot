using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gun : MonoBehaviour
{
    public Transform gunPivot;

    [SerializeField] private TextMeshProUGUI ammoDisplay;  // Make sure this shows in Inspector

    public virtual GameObject bulletPrefab { get; set; } = null;
    public virtual float bulletForce { get; set; } = 20f;
    [SerializeField] public virtual float gunDamage { get; set; } = 10f;

    public virtual int maxAmmo { get; set; }
    public virtual int currentAmmo { get; set; }

    public abstract void Shoot();

    public virtual void Reload()
    {
        
        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
    }

    public void DecreaseAmmo(int count)
    {
        currentAmmo -= count;
        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }

        UpdateAmmoDisplay();
    }

    private void UpdateAmmoDisplay()
    {
        if (ammoDisplay != null)
        {
            ammoDisplay.text = currentAmmo.ToString();
        }
        else
        {
            Debug.LogWarning("Ammo display is not assigned.");
        }
    }

    protected virtual void Start()
    {

        if (transform.parent != null)
        {
            gunPivot = transform.parent.Find("GunPivot")?.transform;

            if (gunPivot == null)
            {
                Debug.LogError("GunPivot not found among siblings! Make sure it is in the same hierarchy level.");
            }
            else
            {
                Debug.Log("GunPivot assigned successfully: " + gunPivot.name);
            }
        }
        else
        {
            Debug.LogError("This object doesn't have a parent, unable to search for GunPivot.");
        }

        bulletPrefab = Resources.Load<GameObject>("Bullets/Default bullet");
        ammoDisplay.text = currentAmmo.ToString();
    }
}
