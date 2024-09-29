using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirMoto : MonoBehaviour, IInteractiveObject
{
    [SerializeField]private GameObject camaraMoto;
    public GameObject Player;
    public Vehiculo_Controller controlador_Moto;
    public GameObject bajarMoto;
   
    public void subirMoto()
    {
        Player.SetActive(false);
        camaraMoto.SetActive(true);
        controlador_Moto.enabled = true;
        bajarMoto.SetActive(true);
    }

    public void interactuar()
    {
        subirMoto();
    }

}
