using UnityEngine;

public class ColorCombineCompleet : MonoBehaviour
{
    public Color mainColor;
    public Color sellectedColor;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = mainColor;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 30)
        {
            sellectedColor = other.GetComponent<ColorBlock>().color;
            Destroy(other.gameObject);

            if (sellectedColor == mainColor)
            {
                Debug.Log("Correct");
            }

            else
            {
                Debug.Log("Not Correct");
            }
        }
    }
}
