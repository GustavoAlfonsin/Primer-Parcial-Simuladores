using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ContenedorPedidos : MonoBehaviour, IInteractiveObject
{
    public List<Pedidio> pedidos;
    public GameObject modeloCliente;
    public GameObject[] destinos;
    public GameObject player;
    public TMP_Text infoPedidos, saldoActual, propinaRecibida;
    private double saldo, propinas;
    private bool enServicio = false;
    void Start()
    {
        pedidos = new List<Pedidio>();
        infoPedidos.gameObject.SetActive(false);
        saldo = 0;
        propinas = 0;
        inicializarClientes();
        crearPedidos();
    }

    // Update is called once per frame
    void Update()
    {
        mostrarEntrega();
        if (enServicio)
        {
            infoPedidos.text = "Pedidos pendientes de entrega: " + pedidosPendientes();
        }
        saldoActual.text = "Monto de jornada " + saldo;
        propinaRecibida.text = "Propina acumulada " + propinas; 
        
    }

    private void inicializarClientes()
    {
        for (int i = 0; i < destinos.Length; i++)
        {
            GameObject nuevoCliente = Instantiate(modeloCliente, 
                                                  destinos[i].transform.position, 
                                                  Quaternion.identity);
            nuevoCliente.transform.SetParent(destinos[i].transform);
            nuevoCliente.SetActive(false);
        }
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

    private void mostrarEntrega()
    {
        var destino = pedidos.FirstOrDefault(x => !x.entregado);
        if (destino != null && enServicio)
        {
            destino.Destino.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            enServicio = false;
            infoPedidos.gameObject.SetActive(false);
            crearPedidos();
            this.GetComponent<MeshRenderer>().enabled = true;
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
        this.GetComponent<MeshRenderer>().enabled = false;
        infoPedidos.gameObject.SetActive(true);
        enServicio = true;
    }

    private int pedidosPendientes()
    {
        return pedidos.Where(x => !x.entregado).Count();
    }

    public void registrarPedidoEntregado(GameObject destino)
    {
        foreach (Pedidio p in pedidos)
        {
            if(p.Destino.transform.position == destino.transform.position)
            {
                saldo += p.montoACobrar;
                propinas += p.propina;
                p.entregado = true;
                destino.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
