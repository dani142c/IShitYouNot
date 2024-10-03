using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2behaviour : MonoBehaviour
{

    public GameObject player;
    public Transform playerPos;

    public Animator animator;

    float movementAbsolute = 0;

    public Rigidbody2D rb;
    public float speed = 1;

        // Vores ondeath event (handler)
    public delegate void DeathHandler();
    public event DeathHandler OnDeath;
    void Start()
    {
        player = GameObject.Find("Main_Player");
        playerPos = player.GetComponent<Transform>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        



        if(Vector3.Distance(playerPos.position, transform.position) > 2){
            Vector3 direction = (playerPos.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);

            movementAbsolute = Math.Abs(direction.x) + Math.Abs(direction.y);
            animator.SetBool("bite", false);
        } else {
            movementAbsolute = 0;
            animator.SetBool("bite", true);
            // damdage player
        }



        animator.SetFloat("speed", movementAbsolute);

    }


            public void Die() // caller den her method når enemy er død
    {
        
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
