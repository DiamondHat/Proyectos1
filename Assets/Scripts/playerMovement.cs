using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 lastMoveDir = Vector2.down;
    private bool isKnockedBack;
    public LayerMask stairs;
    public GameObject popUp;
    //private float timer = 10;
    //private bool countDown=false;


    // Update is called once per frame
    void Update()
    {
        if(isKnockedBack == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
            rb.velocity = moveDirection * speed;

            if (moveDirection != Vector2.zero)
            {
                lastMoveDir = moveDirection;

                if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
                {
                    Flip();
            }
            }

            anim.SetFloat("horizontal", lastMoveDir.x);
            anim.SetFloat("vertical", lastMoveDir.y);
            anim.SetFloat("speed", moveDirection.sqrMagnitude);
        }
       /* if(countDown == true)
        {
            timer -= Time.deltaTime;
        }
       */
        
    }

    void Flip(){
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback (Transform enemy, float force, float stunTime){
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockedBack = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.tag == "Stairs" / (stairs.value & (1 << collision.gameObject.layer)) > 0
        if (collision.gameObject.tag == "Stairs")
        {
            Instantiate(popUp, transform.position, Quaternion.identity);

        }
        else if (collision.CompareTag("Velocity"))
        {
            
            Destroy(collision.gameObject);
            speed = 9;
           /* countDown = true;
            if (timer <= 0)
            {
                speed = 5;
            }
           */
        }
    }


    

}
