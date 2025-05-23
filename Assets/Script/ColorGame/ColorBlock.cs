using UnityEngine;
using TMPro;

public class ColorBlock : MonoBehaviour
{
    public Color color;
    public TMP_Text[] text;


    public void Init(Color colorToSet)
    {
        color = colorToSet;
        
        GetComponent<MeshRenderer>().material.color = color;

        string hex = "#" + ColorUtility.ToHtmlStringRGB(GetComponent<MeshRenderer>().material.color);

        for(int i = 0; i < text.Length; i++)
        {
            text[i].text = hex;
        }
    }
}