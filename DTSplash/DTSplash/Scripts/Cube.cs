using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool go;
    float scale = 0;
    float t;
    float sine;
    void Update()
    {
        if (go)
        {
            Juice();
        }
    }

    void Juice()
    {
        sine = Mathf.Sin(t);
        t +=  10 * Time.deltaTime;
        if (t < 5.5f)
        {
            scale = Mathf.Abs(sine) + 0.3f;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            scale = 1;
            transform.localScale = new Vector3(scale, scale, scale);
            go = false;
        }
    }

    public void Reset()
    {
        go = false;
        scale = 0;
        transform.localScale = new Vector3(scale, scale, scale);
        t = 0;
        sine = 0;
    }
}
