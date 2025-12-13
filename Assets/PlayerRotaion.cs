using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotaion : MonoBehaviour
{

    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    
    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        
        rb.rotation = angle;
    }
}
