using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveEnemiga : MonoBehaviour
{
    public int posnave;
    public Transform indicadorpory, indicadorporx, indicadorporxx;
    public Transform prefab;
    public float time = 0f;
    public bool nodriza;
    public bool QUisort;
    public bool pormorirflag;
    public Transform posestimado;
    public Transform prefabExplition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!nodriza && !QUisort)
            transform.Translate(new Vector2(0f, 0.1f) * Time.deltaTime * 6f);
        else
        if (QUisort) {
            transform.position = Vector3.Lerp(transform.position, posestimado.transform.position, Time.deltaTime * 4f);
            transform.rotation = Quaternion.Lerp(transform.rotation, posestimado.transform.rotation, Time.deltaTime * 4f);
        }

        if (time < 2.5f) time = time + Time.deltaTime;

        if (time >= 2.5f)
        {
            Instantiate(prefab, indicadorpory.position, indicadorpory.rotation);
            if (nodriza)
            {
                Instantiate(prefab, indicadorporx.position, indicadorporx.rotation);
                Instantiate(prefab, indicadorporxx.position, indicadorporxx.rotation);
            }
           
            time = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Daño" ) {

            if (QUisort && !pormorirflag)
            {
                Debug.Log("entro");
                Quicksort sort = FindAnyObjectByType<Quicksort>();
                sort.Quick_sort(sort.listanaves, 0, sort.listanaves.Count - 1);
                sort.AsignarposRotArr();
                GetComponent<SpriteRenderer>().color = Color.red;
                pormorirflag = true;
            }
            else
                if (QUisort && pormorirflag) {
                Debug.Log("muerto");
                Quicksort sort = FindAnyObjectByType<Quicksort>();
                if (prefabExplition != null)
                    Instantiate(prefabExplition, transform.position, transform.rotation);
                sort.SeteoNavesSort();
                
            }

            if (!nodriza && !QUisort) {
                if(prefabExplition!=null)
                Instantiate(prefabExplition, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }

        }
    }
}
