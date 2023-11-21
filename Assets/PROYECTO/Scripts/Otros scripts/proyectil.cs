using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    public float timee=0f;
    public float x = 0f;
    public float y = 2f;
    // Update is called once per frame
    void Update()
    {
        timee += Time.deltaTime;
        if (timee >= 1.5f) Destroy(gameObject);

        transform.Translate(new Vector2(x, y) * Time.deltaTime * 3f);
    }
}
