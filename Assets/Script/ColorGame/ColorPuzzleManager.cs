using UnityEngine;

public class ColorPuzzleManager : MonoBehaviour
{
    public Color[] startColors;
    public GameObject[] startColorCubes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < startColors.Length; i++) {
            startColorCubes[i].GetComponent<ColorBlock>().Init(startColors[i]);
        }
    }
}
