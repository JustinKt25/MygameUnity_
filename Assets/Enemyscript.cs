using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    public float movespeed = 3f;
    public int helat = 10;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = gameObject.findwithtag ("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found in the scene. Make sure the player GameObject has the 'Player' tag assigned.");
        }
    }

    
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * movespeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
    public void TakeDamage(int damage)
    {
        helat -= damage;
        if (helat <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
