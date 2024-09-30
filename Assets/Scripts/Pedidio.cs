using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedidio
{
    public GameObject Destino { get; set; }

    public double montoACobrar { get; set; }

    public double propina { get; set; }

    public Pedidio(GameObject destino)
    {
        this.Destino = destino;
        int centenas = Random.Range(1,7) * 100;
        int decenas = Random.Range(1,10) * 10;
        int unidades = Random.Range(1,10);
        montoACobrar = (double)centenas + decenas + unidades;
        propina = montoACobrar * 10 / 100;
    }
}
