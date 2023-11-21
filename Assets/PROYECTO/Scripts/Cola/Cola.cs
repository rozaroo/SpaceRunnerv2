using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cola : MonoBehaviour
{
    List<Transform> cola = new List<Transform>();


    // Update is called once per frame


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
