using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quicksort : MonoBehaviour
{
    Transform posaux;
    naveEnemiga naveaux;
    int inde;
    public List<Transform> listpuntospos = new List<Transform>(); // Debes asignar tus GameObjects en el inspector
    public List<naveEnemiga> listanaves = new List<naveEnemiga>(); // Debes asignar tus GameObjects en el inspector
    public void Start()
    {
        AsignarposRotArr();
        MexclarNaves();
        MexclarPosNaves();
        ///se pinta el pivote que en este caso es el ultimo
        listanaves[listanaves.Count - 1].name = "Pivote";
        listanaves[listanaves.Count - 1].GetComponent<SpriteRenderer>().color = Color.green;
        listanaves[listanaves.Count - 1].GetComponent<Collider2D>().enabled = true;
        for (int i = 0; i < listanaves.Count - 1; i++)///se apagan los collider de los vertices menos el ultimo porque es el pivote
        {
            listanaves[i].GetComponent<Collider2D>().enabled = false;

        }
    }
    void Update()
    {
        VerificarListas();
    }
    
    public void Quick_sort(List<naveEnemiga> lista,int inicio, int ultimo) { 
    if(inicio < ultimo)
        {
            int pi = Particion(lista, inicio, ultimo);
            Quick_sort(lista, inicio, pi-1);
            
            Quick_sort(lista, pi+1, ultimo);
        }
    }
    
    public int Particion(List<naveEnemiga> lista, int inicio, int ultimo) {

        naveEnemiga pivote = lista[ultimo];
        naveEnemiga temp;
        int i = inicio - 1;

        for(int j= inicio; j < ultimo; j++) {
           
            if (lista[j].posnave <= pivote.posnave)
            {
                i = i + 1;
                temp = lista[i];
                lista[i] = lista[j];
                lista[j] = temp;
            }
        }
        temp = lista[i + 1];
        lista[i + 1] = lista[ultimo];
        lista[ultimo] = temp;
        return i+1;
    }
    

    void MexclarNaves()
    {

        for (int i = 0; i < listanaves.Count; i++)///se mezclan los vertices para no tener el mimso grafo
        {

            inde = Random.Range(i, listanaves.Count);

            naveaux = listanaves[inde];
            listanaves[inde] = listanaves[listanaves.Count - 1];
            listanaves[listanaves.Count - 1] = naveaux;

        }

        
    }
   

    public void AsignarposRotArr()
    {
        for (int i = 0; i < listanaves.Count; i++)///se mezclan los vertices para no tener el mimso grafo
        {
            listanaves[i].posnave = i;
            listanaves[i].posestimado= listpuntospos[i];
        }
    }

    void MexclarPosNaves()
    {
        for (int i = 0; i < listpuntospos.Count; i++)///se mezclan los vertices para no tener el mimso grafo
        {
            inde = Random.Range(i, listpuntospos.Count);
            posaux = listpuntospos[inde];
            listpuntospos[inde] = listpuntospos[listpuntospos.Count - 1];
            listpuntospos[listpuntospos.Count - 1] = posaux;
        }
    }
    public void SeteoNavesSort() {

           for (int i = 0; i < listanaves.Count; i++)///se apagan los collider de los vertices menos el ultimo porque es el pivote
            {
                if (listanaves[i].transform.name == "Pivote")
                {
                    GameObject navedestroy = listanaves[i].gameObject;
                    listpuntospos.RemoveAt(i);
                    listanaves.RemoveAt(i);
                    Destroy(navedestroy);
                    break;
                }

           }
            AsignarposRotArr();
            MexclarNaves();
            MexclarPosNaves();
            ///se pinta el pivote que en este caso es el ultimo
            listanaves[listanaves.Count - 1].name = "Pivote";
            listanaves[listanaves.Count - 1].GetComponent<SpriteRenderer>().color = Color.green;
            listanaves[listanaves.Count - 1].GetComponent<Collider2D>().enabled = true;
            for (int i = 0; i < listanaves.Count - 1; i++) ///se apagan los collider de los vertices menos el ultimo porque es el pivote
            listanaves[i].GetComponent<Collider2D>().enabled = false;
    }
    public void VerificarListas()
    {
        if (listanaves.Count == 0 && listpuntospos.Count == 0) SceneManager.LoadScene(3);
    }
}
