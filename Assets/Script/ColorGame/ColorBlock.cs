using UnityEngine;
using TMPro;

public class ColorBlock : MonoBehaviour
{
    public Color color;
    public string hex;

    public TextMeshProUGUI[] text;

    public Vector3 location;


    public void Start()
    {
        location = transform.position;

        GetComponent<MeshRenderer>().material.color = color;

        hex = "#" + ColorUtility.ToHtmlStringRGB(color);

        foreach (TMP_Text i in text)
        {
            i.text = hex;
        }
    }

    public void SpawnNew()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        Instantiate(gameObject, location, this.transform.rotation);
    }
    

}
