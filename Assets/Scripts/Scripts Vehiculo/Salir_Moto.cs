using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir_Moto : MonoBehaviour
{
    [SerializeField] private GameObject camaraMoto;
    [SerializeField] private GameObject indicarPosicion;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject moto;
    [SerializeField] private Vehiculo_Controller controller_Moto;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            bajarMoto();
        }
    }

    private void bajarMoto()
    {
        Vector3 nuevaPosicion = moto.gameObject.transform.position + Vector3.left;
        nuevaPosicion.y = Player.transform.position.y;
        Player.transform.position = nuevaPosicion;
        Player.SetActive(true);
        // Player.transform.position = sphereRB.transform.position + Vector3.left * 2.5f
        //                             + Vector3.up * 0.5f; 
        camaraMoto.SetActive(false);
        indicarPosicion.SetActive(false);
        CameraMinimap.conduciendo = false;
        controller_Moto.enabled = false;
        gameObject.SetActive(false);
    }
}
