using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculo_Controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float aceleracion;
    [SerializeField] private float turnSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }

    private void movimiento()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        rb.transform.Translate(Vector3.forward * Time.deltaTime * aceleracion * ver);
        rb.transform.Rotate(Vector3.up, turnSpeed * hor * Time.deltaTime);
    }
}
