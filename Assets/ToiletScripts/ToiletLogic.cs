using UnityEngine;

public class ToiletLogic : MonoBehaviour
{
    public Canvas gameOver;  
    void OnTriggerEnter2D(Collider2D collision)
    {
        // VI checker om vores colliding object er tagget som "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            WaveManager.IsGamePaused = true;
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }
    }
}
