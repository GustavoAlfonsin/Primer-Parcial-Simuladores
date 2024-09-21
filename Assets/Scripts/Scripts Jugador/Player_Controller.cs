using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private bool running;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EstaCorriendo();
        movimiento();
        controlAnimaciones();
    }

    private void EstaCorriendo()
    {
        if (Input.GetKey(KeyCode.C))
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    private void movimiento()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        if (running)
        {
            rb.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed * ver);
        }
        else
        {
            rb.transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed * ver);
        }
        rb.transform.Rotate(Vector3.up, turnSpeed * hor * Time.deltaTime);
    }
    private void controlAnimaciones()
    {
        float ver = Input.GetAxisRaw("Vertical");
        if (ver != 0)
        {
            if (running)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Walking", false);
            }
            else
            {
                animator.SetBool("Walking", true);
                animator.SetBool("Running", false);
            }
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Walking", false);
        }
    }
}
