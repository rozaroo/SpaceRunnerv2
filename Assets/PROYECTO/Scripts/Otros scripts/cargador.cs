using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargador: MonoBehaviour
{
    public int cantiMuni = 3;
    [Header("0) cargador ABB" +
            "1) cargador Pila" +
            "..")]
    public int tipoEstructura;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player") {

            collision.transform.GetComponent<nave>().Carga(cantiMuni, tipoEstructura);
            Destroy(this.gameObject);

        }
    }
}
