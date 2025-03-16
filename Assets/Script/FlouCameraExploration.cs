using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FlouCameraExploration : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private DepthOfField depthOfField;

    void Start()
    {
        if (postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume n'est pas assign� !");
            return;
        }

        // V�rifier que le profile est bien d�fini
        if (postProcessVolume.profile == null)
        {
            Debug.LogError("Le PostProcessVolume n'a pas de profil assign� !");
            return;
        }

        // R�cup�rer les effets de vignettage et de flou de profondeur
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out depthOfField);

        if (vignette == null) Debug.LogError("Effet Vignette non trouv� !");
        if (depthOfField == null) Debug.LogError("Effet Depth of Field non trouv� !");
    }

    void Update()
    {
        if (vignette != null)
        {
            vignette.enabled.value = true;
            vignette.intensity.value = Mathf.Lerp(0.3f, 0.6f, Mathf.PingPong(Time.time * 0.5f, 1));
        }

        if (depthOfField != null)
        {
            depthOfField.enabled.value = true;
            depthOfField.focusDistance.value = Mathf.Lerp(3f, 5f, Mathf.PingPong(Time.time * 0.5f, 1));
            depthOfField.aperture.value = 2.8f;
        }
    }
}
