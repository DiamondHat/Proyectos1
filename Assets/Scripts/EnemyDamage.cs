using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1;

    public float knockbackForce; 
    public float stunTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }
    }
}
