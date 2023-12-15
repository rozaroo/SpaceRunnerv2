using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour
{
    public List<Transform> cola = new List<Transform>();

    /*
    public int longCola;
    // Update is called once per frame
    public void Update()
    {
        longCola = cola.Count;
    }
    */

    public void Encolar(Transform proyectil)
    {


        cola.Add(proyectil);


    }

    public Transform Desencolar()
    {
        Transform pryectil = cola[0];
        cola.RemoveAt(0);
        return pryectil;


    }
    public void Cargar(Transform municion)
    {
        Encolar(municion);

    }
}
