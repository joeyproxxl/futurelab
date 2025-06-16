using UnityEngine;
using UnityEngine.UI;

public class GammaAdjuster : MonoBehaviour
{
    [SerializeField] private RawImage targetImage;
    [SerializeField] private Slider gammaSlider;
    
    private Material imageMaterial;

    public MiniGameManager manager;
    
    void Start()
    {
        // Create a new material instance with custom gamma shader
        if (targetImage != null)
        {
            Shader gammaShader = Shader.Find("Custom/UIGamma");
            if (gammaShader != null)
            {
                imageMaterial = new Material(gammaShader);
                targetImage.material = imageMaterial;
            }
            else
            {
                Debug.LogError("Custom/UIGamma shader not found. Please ensure the shader is in the project.");
            }
        }
        
        // Set up slider listener
        if (gammaSlider != null)
        {
            gammaSlider.onValueChanged.AddListener(UpdateGamma);
            // Initialize gamma with slider value (default to 1 if not set)
            UpdateGamma(gammaSlider.value);
        }
    }

    void UpdateGamma(float value)
    {
        if (imageMaterial != null)
        {
            // Set gamma value (slider range 0-2 for typical gamma adjustment)
            imageMaterial.SetFloat("_Gamma", value);
            Debug.Log($"Gamma set to: {value}");
        }

        if (value >= .8f && value <= 1.2f)
        {
            manager.GammaGame = true;
        }

        else
        {
            manager.GammaGame = false;
        }
    }
    
    void OnDestroy()
    {
        if (gammaSlider != null)
        {
            gammaSlider.onValueChanged.RemoveListener(UpdateGamma);
        }
        if (imageMaterial != null)
        {
            Destroy(imageMaterial);
        }
    }
}