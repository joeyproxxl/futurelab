using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorMeng : MonoBehaviour
{
    public Color in1c, in2c;
    public Color outc;

    Vector3 in1v, in2v;
    Vector3 outv;

    void Update()
    {
        in1v.x = in1c.r;
        in1v.y = in1c.g;
        in1v.z = in1c.b;

        in2v.x = in2c.r;
        in2v.y = in2c.g;
        in2v.z = in2c.b;

        outv = in1v + in2v;
        outv = outv / 2;
        
        outc.r = outv.x;
        outc.g = outv.y;
        outc.b = outv.z;

        GetComponent<MeshRenderer>().material.color = outc;
    }
}
