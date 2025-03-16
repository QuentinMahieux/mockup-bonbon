using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FlouCameraExploration : MonoBehaviour
{
    public Volume volume; // Référence au Volume contenant l'effet de flou
    private DepthOfField depthOfField;

    [Range(0f, 10f)] public float blurIntensity = 2f; // Intensité du flou

    private void Start()
    {
        // Vérifie si le volume contient un effet Depth Of Field
        if (volume && volume.profile.TryGet(out depthOfField))
        {
            depthOfField.active = true; // Activer l'effet dès le début
            depthOfField.gaussianStart.value = 0.5f;
            depthOfField.gaussianEnd.value = 5f;
            depthOfField.gaussianMaxRadius.value = blurIntensity;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Touche B pour activer/désactiver
        {
            if (depthOfField != null)
            {
                depthOfField.active = !depthOfField.active;
            }
        }
    }
}
