using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject spherePrefab;
    private Vector2 aimDirection = Vector2.right;

    
   

    
    void Update()
    {
        HandleAiming();
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
      Sphere sphere = Instantiate(spherePrefab, firePoint.position, Quaternion.identity).GetComponent<Sphere>();
      sphere.direction = aimDirection;   
    }

    private void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }
}
