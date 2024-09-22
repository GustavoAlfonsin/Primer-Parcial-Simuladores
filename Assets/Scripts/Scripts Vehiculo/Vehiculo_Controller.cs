using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculo_Controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float aceleracion;
    [SerializeField] private float maxSpeed = 200;
    [SerializeField] private float speed = 0;
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
        speed += ver * aceleracion * Time.deltaTime * 60/100;
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }else if (speed <= 0)
        {
            speed = 0;
        }
        Debug.Log($"Velocidad alcanzada = {speed}");
        rb.transform.Translate(Vector3.forward * speed);
        rb.transform.Rotate(Vector3.up, turnSpeed * hor * Time.deltaTime);
    }
}
