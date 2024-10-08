using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2behaviour : MonoBehaviour
{

    public GameObject player;
    public Transform playerPos;

    public float playerHealth;

    public Animator animator;

    float movementAbsolute = 0;

    public float attackTime = 1;
    public float timer = 0;

    public Rigidbody2D rb;
    public float speed = 1;
    public float damage = 10;

        // Vores ondeath event (handler)
    public delegate void DeathHandler();
    public event DeathHandler OnDeath;
    void Start()
    {
        player = GameObject.Find("Main_Player");
        playerPos = player.GetComponent<Transform>();

        playerHealth = GetComponent<Player>().health;

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

        if(movementAbsolute == 0){
            timer += Time.deltaTime;

            Attack();
        } else {
            timer = 0;
        }

    }


    public void Die() // caller den her method når enemy er død
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void Attack(){
        if(timer >= attackTime){
            Debug.Log("attackSuccessful");
            playerHealth -= damage; //make this shit
            timer = 0;
        }
    }
}
