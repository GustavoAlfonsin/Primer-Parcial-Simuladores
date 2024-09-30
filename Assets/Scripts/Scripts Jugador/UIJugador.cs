using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIJugador : MonoBehaviour
{
    public List<Pedidio> pedidos;
    public TMP_Text infoPedidos;
    private double saldo, propinas;
    // Start is called before the first frame update
    void Start()
    {
        pedidos = new List<Pedidio>();
        saldo = 0;
        propinas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        infoPedidos.text = "Pedidos pendientes de entrega: " + pedidos.Count;
    }

    public void cargarPedidos(List<Pedidio> pedidosEnCola)
    {
        pedidos = pedidosEnCola;
    }

    public void cobrarPedido()
    {
        saldo += pedidos[0].montoACobrar;
        propinas += pedidos[0].propina;
        pedidos.Remove(pedidos[0]);

    }
}
