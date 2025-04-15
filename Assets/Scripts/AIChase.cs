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

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isChasing == true))
        {


            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = (player.transform.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

   public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking",true);
        
        if (context.canceled)
        {
            animator.SetBool("isWalking",false);
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
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
