using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir_Moto : MonoBehaviour
{
    [SerializeField] private SubirMoto subirMoto;
    [SerializeField] private GameObject camaraMoto;
    [SerializeField] private GameObject Player;
    [SerializeField] private Vehiculo_Controller controller_Moto;
    // Start is called before the first frame update
    void Start()
    {
        Player = subirMoto.Player;
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
        Player.SetActive(true);
        Player.transform.position = gameObject.transform.position; 
        camaraMoto.SetActive(false);
        controller_Moto.enabled = false;
        subirMoto.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
