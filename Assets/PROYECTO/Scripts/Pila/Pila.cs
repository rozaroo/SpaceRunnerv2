using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : MonoBehaviour
{
    List<Transform> pila = new List<Transform>();
    /*
    public int longPila;
    // Update is called once per frame
    public void Update()
    {
        longPila = pila.Count;
    }
    */

    public void Push( Transform proyectil)
    {
        

        pila.Add( proyectil);


    }

    public Transform Pop()
    {
        Transform pryectil = pila[pila.Count-1];
        pila.RemoveAt(pila.Count - 1);
        return pryectil;


    }
    public void Cargar( Transform municion)
    {
           Push(municion);

    }

 }
