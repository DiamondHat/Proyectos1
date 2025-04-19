using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if(health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
