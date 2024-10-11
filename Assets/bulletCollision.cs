using UnityEngine;
using UnityEditor;

public class BulletCollision : MonoBehaviour
{

    public AudioClip[] damageEnemy1;
    public AudioClip[] damageEnemy2;

    public void Start(){
        damageEnemy1 = Resources.LoadAll<AudioClip>("sfx/EnemyType1SFX/EnemyType1HurtSFX");
        damageEnemy2 = Resources.LoadAll<AudioClip>("sfx/EnemyType2SFX/EnemyType2HurtSFX");
    }
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

            EnemyOnHit HitResponseScript = collision.gameObject.GetComponent<EnemyOnHit>();

            Transform enemyTransform = collision.gameObject.GetComponent<Transform>();

            if (enemyHealth != null)
            {
                if(collision.gameObject.name == AssetDatabase.LoadAssetAtPath<GameObject>("Assets/EnemyType1.prefab").name + "(Clone)"){
                    SoundManager.instance.playRANDSound(damageEnemy1, enemyTransform, 1f);
                    Debug.Log("enemy2collision");
                } else if(collision.gameObject.name == AssetDatabase.LoadAssetAtPath<GameObject>("Assets/EnemyType2.prefab").name + "(Clone)"){
                    SoundManager.instance.playRANDSound(damageEnemy2, enemyTransform, 1f);
                }

                enemyHealth.TakeDamage(gunDamage);
                HitResponseScript.HitResponse();
            }

            Destroy(gameObject); // Destroy bullet after dealing damage
        }
        else
        {
            Destroy(gameObject); // Destroy bullet if it hits anything else
        }
    }
}
