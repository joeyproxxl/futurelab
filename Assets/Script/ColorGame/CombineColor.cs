using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class CombineColor : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public GameObject colorObj;
    public Transform newColorSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 31 || other.gameObject.layer == 30)
        {
            if (color1 == color2)
            {
                color1 = other.GetComponent<ColorBlock>().color;
                SpawnNew(color1);
                Destroy(other.gameObject);
                return;
            }

            else
            {
                color2 = other.GetComponent<ColorBlock>().color;
                SpawnNew(color2);
                Destroy(other.gameObject);
            }

            SpawnNew(CombineColors(color1, color2));

            color1 = Color.black;
            color2 = color1;
        }
    }

    Color CombineColors(Color c1, Color c2)
    {
        Color newColor = new Color();
        Vector3 colorVector = new Vector3();

        // Average the RGB components
        colorVector.x = (c1.r + c2.r) / 2;
        colorVector.y = (c1.g + c2.g) / 2;
        colorVector.z = (c1.b + c2.b) / 2;

        // Find the maximum component
        float maxComponent = Mathf.Max(colorVector.x, colorVector.y, colorVector.z);

        // If maxComponent is not 0, scale all components so the maximum becomes 1
        if (maxComponent > 0)
        {
            colorVector = colorVector / maxComponent;
        }

        newColor.r = colorVector.x;
        newColor.g = colorVector.y;
        newColor.b = colorVector.z;
        newColor.a = 1;

        return newColor;
    }

    public void SpawnNew(Color newColorin)
    {
        GameObject newColorObj = Instantiate(colorObj, newColorSpawn);
        newColorObj.GetComponent<Rigidbody>().isKinematic = false;
        newColorObj.GetComponent<Rigidbody>().useGravity = true;
        newColorObj.GetComponent<ColorBlock>().Init(newColorin);
    }
}
