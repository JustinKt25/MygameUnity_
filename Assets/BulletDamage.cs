using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 1;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        Enemyscript enemy = other.GetComponent<Enemyscript>();

        if (enemy != null)
        {
            
            enemy.TakeDamage(damageAmount);

            
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            
            Destroy(gameObject);
        }
        
    }
}
