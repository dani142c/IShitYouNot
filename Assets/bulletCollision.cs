using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = Player.instance;
        float gunDamage = Player.instance.equippedGun.gunDamage;
        // Find the player object by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); 
        if (playerObject == null)
        {
            Debug.LogError("Player object not found!");
            Destroy(gameObject);
            return;
        }

        if (player == null)
        {
            Debug.LogError("Player component not found on the object!");
            Destroy(gameObject);
            return;
        }

        if (player.equippedGun != null)
        {
            Debug.Log("Player has gun");
        }

        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(gunDamage);
            }

            Destroy(gameObject); // Destroy bullet after dealing damage
        }
        else
        {
            Destroy(gameObject); // Destroy bullet if it hits anything else
        }
    }
}
