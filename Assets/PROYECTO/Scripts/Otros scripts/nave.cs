using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class nave : MonoBehaviour
{
    [Header("***********")]
    [Header("*********** ")]
    [Header("EL ARBOL SE PUEDE VER EN LA ")]
    [Header("JERARQUIA AL DARLE PLAY")]
    public node raiz = null;
    public node root = null;
    abb1 bst;
    public bool primero;
    public int[] a = new int[52];
    public int municion = 0;
    public Transform indicadorpory;
    public int vida = 3;
    public Transform explocion;
    public Pila pila;
    public Cola cola;
    [Header("TIPO DE ARMA TIENE EL JUGADOR")]
    public int ConArma_tipo=-99;
    [Header("PREFABS PARA INSTANCIAR MUNIS")]
    public Transform prefab_MuniABB;
    public Transform prefab_MuniPila;
    public Transform prefab_MuniCola;
    Animator anim;
    public int municionReal;
    public Text ammoDisplay;

    //HUD/UI
    
    public GameObject[] vidas;
    public void Start()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        anim = GetComponent<Animator>();
        bst = new abb1();
        raiz = root;
        pila = new Pila();
        for (municion = 0; municion < 7; municion++)
        {
            if(prefab_MuniABB!=null) root = bst.insert(root, municion, this, prefab_MuniABB,municion);
        }

        if (escenaActual.name=="NIVEL 2")
        {
            municion = 2;
        }

        //Debug.Log(root.value);
        //Debug.Log(raiz.right.value);
        root = raiz;
        //bst.Mostrar(root);
        bst.RecorrerInorder(root);
        root = raiz;
        bst.Descargar(root,this);
        
        // Debug.Log(raiz.value);
    }
    public void Update()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(Horizontal, Vertical)*Time.deltaTime*6f);

        root = raiz;
        if (Input.GetMouseButtonDown(0) && municion > 1)
        {
            if (ConArma_tipo == 0) Instantiate(bst.Descargar(root, this), indicadorpory.position, indicadorpory.rotation);
            else
            if (ConArma_tipo == 1)
            {
                Instantiate(pila.Pop(), indicadorpory.position, indicadorpory.rotation);
                municion--;
            }
            else
            if (ConArma_tipo == 2)
            {
                Instantiate(cola.Desencolar(), indicadorpory.position, indicadorpory.rotation);
                municion--;
            }
        }
        bst.RecorrerInorder(root);

        municionReal = municion - 1;

        ammoDisplay.text = municionReal.ToString();

    }


    public void Carga(int cantidad,int tipo) {
        ConArma_tipo = tipo;
        //if (Input.GetKeyDown(KeyCode.H)) tipo == 0;
        if (tipo == 0)///ABB arma
        {
            for (int i = 0; i < cantidad; i++)
            {
                municion++;
                if (prefab_MuniABB != null) root = bst.insert(root, municion, this, prefab_MuniABB,i);
            }
        }
        else
        if (tipo == 1)///Pila arma
        {
            
            for (int i = 0; i < cantidad; i++)
            {
                municion++;
                if (prefab_MuniPila != null) pila.Push(prefab_MuniPila);
            }
        }

        else///Cola arma
        {
            
            for (int i = 0; i < cantidad; i++)
            {
                municion++;
                if (prefab_MuniPila != null) cola.Encolar(prefab_MuniCola);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (vida > 0 && collision.transform.tag == "ObjetoDañoE")
        {
            vida = vida - 1;
            anim.SetTrigger("daño");
            DesactivarVida(vida);
        }
        else
            if (vida <= 0) {
            Instantiate(explocion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            SceneManager.LoadScene(4);
        }
    }
    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
}
