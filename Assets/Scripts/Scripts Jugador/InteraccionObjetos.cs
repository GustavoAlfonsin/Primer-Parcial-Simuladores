using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using Debug = UnityEngine.Debug;

public class InteraccionObjetos : MonoBehaviour
{
    public LayerMask mask;
    public float distance = 3f;
    private RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
                out hit, distance))
        {
            if (hit.collider.tag == "Objeto Interactivo")
            {
                Debug.Log("Objeto interactivo detectado");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.GetComponent<IInteractiveObject>().interactuar();
                }
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* distance, Color.red);
        
    }
}
