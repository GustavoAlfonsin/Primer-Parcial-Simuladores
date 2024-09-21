using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw ("Vertical");

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + 
                                transform.right * hor).normalized;
            rb.velocity = direction * walkSpeed;
            animator.SetBool("Walking",true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Walking", false);
        }

    }
}
