using UnityEngine;

public class ToiletLogic : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // VI checker om vores colliding object er tagget som "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    // Vores function til at stoppe spillet
    void GameOver()
    {
        Debug.Log("Enemy touched the toilet. Game Over!");
        // Stopper spillet
        Time.timeScale = 0;
    }
}
