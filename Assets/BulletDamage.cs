using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 1;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tabrakan terdeteksi dengan: " + other.gameObject.name);

        Enemyscript enemy1 = other.GetComponent<Enemyscript>();

        if (enemy1 != null)
        {
            
            enemy1.TakeDamage(damageAmount);

            
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            
            Destroy(gameObject);
        }
        
    }
}
