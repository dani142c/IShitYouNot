using System;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{
    public GameObject toilet;
    public Transform toiletPos;

    public Animator animator;

    float movementAbsolute = 0;
    public Rigidbody2D rb;
    public float speed = 1;
    
    // Vores ondeath event (handler)
    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    public float health = 100;

    void Start()
    {
        toilet = GameObject.Find("Toilet");
        toiletPos = toilet.GetComponent<Transform>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector3 direction = (toiletPos.position - transform.position).normalized;
        Vector3 targetPosition = transform.position + direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);

        movementAbsolute = Math.Abs(direction.x) + Math.Abs(direction.y);

        animator.SetFloat("speed", movementAbsolute);
    }

        public void Die() // caller den her method når enemy er død
    {
        
        OnDeath?.Invoke();
        Destroy(gameObject);
    }


}
