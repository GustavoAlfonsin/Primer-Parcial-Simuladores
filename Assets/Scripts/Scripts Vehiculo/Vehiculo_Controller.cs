using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehiculo_Controller : MonoBehaviour
{
    [SerializeField] private float moveInput, steerInput, rayLength, currentVelocityOffset;
    public float maxSpeed, acceleration, steerStrenght, gravity, bikeTiltIncrement = 0.9f;
    public float zTiltAngle = 45f;
    [HideInInspector] public Vector3 velocity;
    [Range(1,10)]
    public float breakingFactor;

    public LayerMask derivableSurface;
    RaycastHit hit;
    public bool inGround;

    [SerializeField] private Rigidbody sphereRB, BikeBody;

    // Start is called before the first frame update
    void Start()
    {
        sphereRB.transform.parent = null;
        BikeBody.transform.parent = null;

        rayLength = sphereRB.GetComponent<SphereCollider>().radius + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        transform.position = sphereRB.transform.position;

        velocity = BikeBody.transform.InverseTransformDirection(BikeBody.velocity);
        currentVelocityOffset = velocity.z / maxSpeed;
        
    }
    private void FixedUpdate()
    {
        movimiento();
    }

    private void movimiento()
    {
        if (Grounded())
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                Aceleracion();
                rotacion();
            }
            Brake();
        }
        else
        {
            Gravity();
        }
        BikeTilt();
    }

    private void Aceleracion()
    {
        sphereRB.velocity = Vector3.Lerp(sphereRB.velocity,
                                         maxSpeed * moveInput * transform.forward,
                                         Time.fixedDeltaTime * acceleration);
    }

    private void rotacion()
    {
        transform.Rotate(0,steerInput * moveInput * steerStrenght * Time.fixedDeltaTime,0,Space.World);
    }

    private void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sphereRB.velocity *= breakingFactor / 10;
        }
    }

    private bool Grounded()
    {
        float radius = rayLength - 0.5f;
        Vector3 origin = sphereRB.transform.position + radius * Vector3.up;
        if (Physics.SphereCast(origin, radius + 0.5f, -transform.up,
                                out hit, rayLength, derivableSurface))
        {
            inGround = true;
            return true;
        }
        else
        {
            inGround = false;
            return false;
        }
    }

    private void Gravity()
    {
        sphereRB.AddForce(gravity * Vector3.down, ForceMode.Acceleration);
    }

    private void BikeTilt()
    {
        float xRot = (Quaternion.FromToRotation(BikeBody.transform.up, hit.normal) *
                        BikeBody.transform.rotation).eulerAngles.x;

        float zRot = 0;
        if(currentVelocityOffset > 0)
        {
            zRot = -zTiltAngle * steerInput * currentVelocityOffset;
        }

        Quaternion targetRot = Quaternion.Slerp(BikeBody.transform.rotation,
                                Quaternion.Euler(xRot,
                                transform.eulerAngles.y, zRot),
                                bikeTiltIncrement);

        Quaternion newRotation = Quaternion.Euler(targetRot.eulerAngles.x, 
                                transform.eulerAngles.y, targetRot.eulerAngles.z);

        BikeBody.MoveRotation(newRotation);
    }
}
