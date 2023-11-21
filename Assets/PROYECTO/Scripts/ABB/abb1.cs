using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abb1 : MonoBehaviour
{
    public node insert(node root, int v, nave navee, Transform prefab)
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
        }
        else if (v > root.value)
        {
            node abbR = insert(root.right, v, navee, prefab);
            root.right = abbR;
            abbR.gameObject.transform.parent = root.transform;
        }
        else
        {
            node abbLef = insert(root.left, v, navee, prefab);
            root.left = abbLef;
            abbLef.gameObject.transform.parent = root.transform;
            
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
    public void Mostrar(node root)
    {
        if (root!= null) Debug.Log(root.value);
        if (root.left != null) Mostrar(root.left);

        else
         if (root.right != null) Mostrar(root.right);

    }
    public void traverse(node root)
    {
        if (root == null) return;
        traverse(root.left);
        traverse(root.right);
    }
}
