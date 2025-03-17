using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Enum pour la sélection des caméras
    public enum CameraOption
    {
        CameraX,
        CameraY,
        CameraZ
    }

    public Camera[] cameras;           // Tableau de caméras à basculer
    public CameraOption selectedCamera; // Caméra actuellement sélectionnée
    public Vector3[] cameraPositions; // Positions des caméras
    public float[] zoomLevels;        // Niveaux de zoom des caméras (Field of View)

    private Camera currentCamera;     // Caméra actuellement active

    private void Start()
    {
        // Désactiver toutes les caméras au démarrage
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Initialiser avec la caméra sélectionnée
        SwitchCamera(selectedCamera);
    }

    private void Update()
    {
        // Vérifier si la caméra sélectionnée a changé
        if (currentCamera != cameras[(int)selectedCamera])
        {
            SwitchCamera(selectedCamera);
        }
    }

    // Fonction pour changer de caméra et appliquer la position et le zoom
    private void SwitchCamera(CameraOption newCamera)
    {
        // Désactiver toutes les caméras
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Activer la nouvelle caméra
        currentCamera = cameras[(int)newCamera];
        currentCamera.gameObject.SetActive(true);

        // Appliquer la position et le zoom à la caméra sélectionnée
        currentCamera.transform.position = cameraPositions[(int)newCamera];
        currentCamera.fieldOfView = zoomLevels[(int)newCamera];
    }
}
