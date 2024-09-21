using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirMoto : MonoBehaviour
{
    [SerializeField]private GameObject camaraMoto;
    public GameObject Player;
    [SerializeField]private bool puedeEntrar;
    public Vehiculo_Controller controlador_Moto;
    public GameObject bajarMoto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            subirMoto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Player = other.gameObject;
            puedeEntrar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            puedeEntrar = false;
        }
    }

    public void subirMoto()
    {
        if (puedeEntrar)
        {
            Player.SetActive(false);
            camaraMoto.SetActive(true);
            controlador_Moto.enabled = true;

            bajarMoto.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
