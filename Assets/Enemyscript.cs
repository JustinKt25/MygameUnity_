using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
        
        public float movespeed = 3f;
        public int health = 10;

        private Transform Player;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            
            Player = GameObject.FindWithTag("Player")?.transform;

            if (Player == null)
            {
                Debug.LogError("Player not found in the scene. Make sure the player GameObject has the 'Player' tag assigned.");
            }
        }

        void FixedUpdate()
        {
            if (Player != null)
            {
                Vector2 direction = (Player.position - transform.position).normalized;
                rb.velocity = direction * movespeed;

                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
            }
        }

        
        public void TakeDamage(int damage)
        {
            health -= damage; 
            if (health <= 0)
            {
                die();
            }
        }

        void die()
        {
            
            Destroy(gameObject);
        }
        
    }
