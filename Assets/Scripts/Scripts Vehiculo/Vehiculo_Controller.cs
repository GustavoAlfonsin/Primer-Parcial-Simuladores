using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculo_Controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float frenar = 75;
    [SerializeField] WheelCollider rueda1;
    //[SerializeField] WheelCollider rueda2;
    [SerializeField] Transform llanta1;
    //[SerializeField] Transform llanta2;
    public float speed = 150;
    [SerializeField] float actualSpeed;
    private float maxSpeed = 300;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        actualSpeed = (2 * Mathf.PI * rueda1.radius) * rueda1.rpm * 60/100;
        llanta1.localEulerAngles = new Vector3(0,rueda1.steerAngle,0);
        //llanta2.localEulerAngles = new Vector3(0, rueda2.steerAngle, 0);

    }
    private void FixedUpdate()
    {
        if (actualSpeed < maxSpeed)
        {
            rueda1.motorTorque = speed * Input.GetAxis("Vertical");
            //rueda2.motorTorque = speed * Input.GetAxis("Vertical");
        }
        else
        {
            rueda1.motorTorque = 0;
            //rueda2.motorTorque = 0;
        }

        rueda1.steerAngle = 40 * Input.GetAxis("Horizontal");
        //rueda2.steerAngle = 40 * Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") == 0)
        {
            rueda1.brakeTorque = frenar;
           // rueda2.brakeTorque = frenar;
        }
        else
        {
            rueda1.brakeTorque = 0;
            //rueda2.brakeTorque = 0;
        }
    }


}
