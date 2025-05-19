using UnityEngine;

public class CombineColor : MonoBehaviour
{
    public Color color1;
    public Color color2;

    public Vector3 colorV;
    public Color combined;

    public GameObject newColor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 31)
        {
            if (color1 == color2)
            {
                color1 = other.GetComponent<ColorBlock>().color;
                other.GetComponent<ColorBlock>().SpawnNew();
                Destroy(other.gameObject);
                return;
            }

            else
            {
                color2 = other.GetComponent<ColorBlock>().color;
                other.GetComponent<ColorBlock>().SpawnNew();
                Destroy(other.gameObject);
            }

            Combinecollors(color1);
            Combinecollors(color2);
            SetNewColor();

            GameObject colorCombined = Instantiate(newColor);
            colorCombined.GetComponent<ColorBlock>().color = combined;
            colorCombined.GetComponent<ColorBlock>().Start();

            color1 = Color.black;
            color2 = color1;
            colorV = Vector3.zero;
        }
    }

     void Combinecollors(Color i)
    {
        colorV.x += i.r;
        colorV.y += i.g;
        colorV.z += i.b;
    }

    void SetNewColor()
    {   
        combined.r = colorV.x;
        combined.g = colorV.y;
        combined.b = colorV.z;
    }
}
