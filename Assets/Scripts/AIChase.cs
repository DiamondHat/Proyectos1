using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private bool isChasing;
    private Vector2 moveInput;
    private Animator animator;
    private Rigidbody2D rb
        ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((isChasing == true))
        {
            Vector3 Displacement = ((player.transform.position - transform.position).normalized * speed);
            Vector2 Displacement2D = new Vector2(Displacement.x,Displacement.y);
            rb.velocity = Displacement2D;
        }
    }

   public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking",true);
        
        if (context.canceled)
        {
            animator.SetBool("isWalking",false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChasing = true;
        }
    }

    



    /*  private void OnTriggerExit2D(Collider2D collision)
      {
          isChasing = false;
      }
    */
}
