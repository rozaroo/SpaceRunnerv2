using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abb1 : MonoBehaviour
{
    public node insert(node root, int v, nave navee, Transform prefab, int order)
    {
        if (root == null)
        {
            GameObject nodooo = new GameObject();
            nodooo.name = "nodo";
            nodooo.AddComponent<node>();
            nodooo.GetComponent<node>().prefab = prefab;
            root = nodooo.GetComponent<node>();
            root.value = v;
            if (navee.primero == false)
            {
                GameObject ABB = new GameObject();
                ABB.name = "ABB";
                nodooo.transform.parent = ABB.transform;
                nodooo.name = "Raiz";
                navee.raiz = root;
                navee.primero = true;
            }
            root.order = order; //Asigna el valor de orden al nodo
        }
        else
        {
            if (v < root.value)
            {
                root.left = insert(root.left, v, navee, prefab,order);
                root.left.gameObject.transform.parent = root.transform;
            }
            if (v > root.value)
            {
                root.right = insert(root.right, v, navee, prefab,order);
                root.right.gameObject.transform.parent = root.transform;
            }
        }
        return root;
    }

    public Transform  Descargar(node root,nave nav)
    {
        Transform prefab;
        if (root.right != null) return Descargar(root.right, nav);
        else
        {
            nav.municion = nav.municion - 1;
            prefab = root.prefab;
            Destroy(root.gameObject);
            return prefab;
        }
    }
    /*
    public void Mostrar(node root)
    {
        if (root!= null) Debug.Log(root.value);
        if (root.left != null) Mostrar(root.left);

        else
         if (root.right != null) Mostrar(root.right);

    }
    */
    public void traverse(node root)
    {
        if (root == null) return;
        traverse(root.left);
        traverse(root.right);
    }
    public void RecorrerInorder(node root)
    {
        if (root != null)
        {
            RecorrerInorder(root.left);
            Debug.Log("Valor: " + root.value + " - Orden: " + root.order); //Muestra el nodo actual
            RecorrerInorder(root.right);
        }
    }
}
