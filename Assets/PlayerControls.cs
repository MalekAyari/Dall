using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    
    public List<string> rhymes = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<DialogueManager>().playing) 
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.velocity = moveInput * speed;

            animator.SetFloat("Movement", moveInput.magnitude);
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        } 

        /*
            if (moveInput.x > 0)
                animator.Play("Move Right");
            if (moveInput.x < 0)
                animator.Play("Move Left");
            if (moveInput.y > 0)
                animator.Play("Move Up");
            if (moveInput.y < 0)
                animator.Play("Move Down");
        */
        
    }
}
