using UnityEngine;

public class ColorCombineCompleet : MonoBehaviour
{
    public Color mainColor;
    public Color sellectedColor;

    public MiniGameManager manager;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = mainColor;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 31)
        {
            sellectedColor = other.GetComponent<ColorBlock>().color;
            Destroy(other.gameObject);

            if (sellectedColor.r == mainColor.r && sellectedColor.g == mainColor.g && sellectedColor.b == mainColor.b)
            {
                manager.collorCombineGame = true;
            }

            else
            {
                manager.collorCombineGame = true;
            }
        }
    }
}
