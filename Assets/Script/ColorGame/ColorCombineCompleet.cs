using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCombineCompleet : MonoBehaviour
{
    public Color mainColor;
    public Color sellectedColor;

    public MiniGameManager manager;

    void Start()
    {
        GetComponent<RawImage>().color = sellectedColor; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 31)
        {
            sellectedColor = other.GetComponent<ColorBlock>().color;
            Destroy(other.gameObject);

            GetComponent<RawImage>().color = sellectedColor;

            if (sellectedColor.r == mainColor.r && sellectedColor.g == mainColor.g && sellectedColor.b == mainColor.b)
            {
                manager.collorCombineGame = true;
            }
            
            else manager.collorCombineGame = false;
        }
    }
}
