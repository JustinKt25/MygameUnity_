using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public float fireRate = 0.5f;   
    public float bulletSpeed = 10f; 

    private float nextFireTime = 0f;

    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) 
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        rb.velocity = firePoint.up * bulletSpeed;

        
        Destroy(bullet, 2f); 
    }
}
