using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorPedidos : MonoBehaviour, IInteractiveObject
{
    public List<Pedidio> pedidos;
    public GameObject[] destinos;
    public GameObject player;
    void Start()
    {
        pedidos = new List<Pedidio>();
        crearPedidos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void crearPedidos()
    {
        pedidos.Clear();
        for (int i = 0; i < 5; i++)
        {
            GameObject destinoElegido;
            do
            {
              destinoElegido = destinos[Random.Range(0, destinos.Length)];
            } while (destinoYaElegido(destinoElegido));

            Pedidio nuevoPedido = new Pedidio(destinoElegido);
            Debug.Log("Se creo un nuevo pedido");
            pedidos.Add(nuevoPedido);
        }
    }

    private bool destinoYaElegido(GameObject destinoElegido)
    {
        foreach (Pedidio p in pedidos)
        {
            if (p.Destino.transform.position == destinoElegido.transform.position) 
            {
                return true;
            }
        }
        return false;
    }

    public void interactuar()
    {
        player.GetComponent<UIJugador>().cargarPedidos(pedidos);
        this.gameObject.SetActive(false);
    }
}
