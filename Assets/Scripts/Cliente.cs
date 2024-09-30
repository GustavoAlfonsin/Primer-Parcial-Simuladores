using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour, IInteractiveObject
{
    [SerializeField] private GameObject infoPedidos;

    private void Start()
    {
        infoPedidos = GameObject.Find("RecogedorPedidos");
        //padre = this.transform.parent.GetComponent<GameObject>().gameObject;
    }
    public void interactuar()
    {
        GameObject padre = transform.parent.gameObject;
        infoPedidos.GetComponent<ContenedorPedidos>().registrarPedidoEntregado(padre);
    }
}
