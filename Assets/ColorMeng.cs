using UnityEngine;

public class ColorMeng : MonoBehaviour
{
    public Color[] inc;
    public Color outc;
    Vector3 outv;

    void Update()
    {
        updateColor();
    }

    void updateColor()
    {
        foreach (Color i in inc)
        {
            Combinecollors(i);
        }

        SetNewColor();


        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("#" + ColorUtility.ToHtmlStringRGB(outc));
        }
    }

    void Combinecollors(Color i)
    {
        outv.x += i.r;
        outv.y += i.g;
        outv.z += i.b;
    }

    void SetNewColor()
    {
        outv = outv / inc.Length;
        
        outc.r = outv.x;
        outc.g = outv.y;
        outc.b = outv.z;

        GetComponent<MeshRenderer>().material.color = outc;

        outv = Vector3.zero;
    }
}
