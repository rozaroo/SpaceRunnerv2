using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertice : MonoBehaviour
{
    public List<vertice> verAdyacent = new List<vertice>();
    public List<float> aristaspesos = new List<float>();
    vertice auxv;
    public float menorpeso;
     int i = 0;
    public int pos;
    Dijtra dijstr;
     void calculopeso()
    {
        ///se elije de la lista de verAdyacent cual de los vertices  tiene menor peso 
            menorpeso = aristaspesos[0];
            for ( i = 1; i < aristaspesos.Count; i++)
            {
                if (aristaspesos[i] < menorpeso)
                {
                    menorpeso = aristaspesos[i];
                    pos = i;
                }
            }
    }
        public void Update()
        {
            foreach (vertice ver in verAdyacent) {
                Debug.DrawLine(transform.position, ver.transform.position);
             }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Daño")
        {
            
            ///el vertice propio
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Collider2D>().enabled = true;
            if (transform.name != "Destino")
            {
                calculopeso();
                /// ///se elijio la arista de menor peso con el indice i y esto da resultado el vertice indice i
                verAdyacent[pos].GetComponent<SpriteRenderer>().color = Color.green;
                verAdyacent[pos].GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                dijstr = FindAnyObjectByType<Dijtra>();
                dijstr.Rojos();
                Destroy(this.gameObject);
            }

        }
    }
}
