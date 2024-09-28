using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 inputMovimiento;
    private Vector2 inputRotacion;

    private Animator animator;
    private Transform cam;
    float rotX;
    private bool running;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        rotX = cam.eulerAngles.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputMovimiento.x = Input.GetAxis("Horizontal");
        inputMovimiento.y = Input.GetAxis("Vertical");

        inputRotacion.x = Input.GetAxis("Mouse X") * turnSpeed;
        inputRotacion.y = Input.GetAxis("Mouse Y") * turnSpeed;

        corriendo();
        controlAnimaciones();
    }

    private void FixedUpdate()
    {
        float vel = running ? runSpeed : walkSpeed;

        rb.velocity = transform.forward * vel * inputMovimiento.y
                        + new Vector3(0, rb.velocity.y, 0);

        rotX -= inputRotacion.y;
        rotX = Mathf.Clamp(rotX, -30, 30);
        cam.localRotation = Quaternion.Euler(rotX,0,0);
        transform.rotation *= Quaternion.Euler(0, inputRotacion.x, 0);
    }

    void corriendo()
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
