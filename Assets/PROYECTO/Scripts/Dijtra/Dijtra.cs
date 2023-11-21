using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dijtra : MonoBehaviour
{
    public Animator anim;
    public GameObject explociones;
    public vertice[] vertices; // Debes asignar tus GameObjects en el inspector
    vertice veraux;
    int inde;
    float peso;
    int j=0;
    public void Awake()
    {
        Debug.Log(vertices.Length);
        for (int i = 0; i < vertices.Length; i++)///se mezclan los vertices para no tener el mimso grafo
            MexclarVertices();
        for (int i = 1; i < vertices.Length; i++)///se apagan los collider de los vertices
            vertices[i].GetComponent<Collider2D>().enabled = false;
        vertices[0].transform.name = "Origen";
        vertices[0].GetComponent<SpriteRenderer>().color = Color.green;
        vertices[vertices.Length-1].transform.name = "Destino";
        
        for (int i = 0; i < vertices.Length ; i++){///se generan los vertices adyacentes por  cada vertice

            for ( j = i+1; j <vertices.Length ; j++)
            {  
                veraux = vertices[Random.Range(j, vertices.Length - 1)];
                peso = Random.Range(0, 10);
                while (vertices[i].aristaspesos.Contains(peso) == true)
                {
                    peso = Random.Range(0, 10);
                }
                if (vertices[i].verAdyacent.Contains(veraux) == false)
                {
                    vertices[i].verAdyacent.Add(veraux);
                    vertices[i].aristaspesos.Add(peso);
                }
            }
           
        }
        veraux = vertices[vertices.Length - 1];
        if (vertices[0].verAdyacent.Contains(veraux) == true) vertices[0].verAdyacent.Remove(veraux);
        veraux = vertices[0];
        if (vertices[vertices.Length - 1].verAdyacent.Contains(veraux) == true) vertices[vertices.Length - 1].verAdyacent.Remove(veraux);
        vertices[0].aristaspesos.RemoveAt(0);
    }
    void MexclarVertices() {

        for (int i = 0; i < vertices.Length; i++)///se mezclan los vertices para no tener el mimso grafo
        {
            inde = Random.Range(i, vertices.Length);
            veraux = vertices[inde];
            vertices[inde] = vertices[vertices.Length - 1];
            vertices[vertices.Length - 1] = veraux;
        }
    }
    public void Rojos() {
        for (int i = 0; i < vertices.Length; i++)///se apagan los collider de los vertices 
        {
            vertices[i].GetComponent<SpriteRenderer>().color = Color.red;
            vertices[i].GetComponent<naveEnemiga>().enabled = false;
            explociones.SetActive(true);
            anim.SetBool("destroy", true);
            SceneManager.LoadScene(2);
        }
    }
}

