using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Enum pour la s�lection des cam�ras
    public enum CameraOption
    {
        CameraX,
        CameraY,
        CameraZ
    }

    public Camera[] cameras;           // Tableau de cam�ras � basculer
    public CameraOption selectedCamera; // Cam�ra actuellement s�lectionn�e
    public Vector3[] cameraPositions; // Positions des cam�ras
    public float[] zoomLevels;        // Niveaux de zoom des cam�ras (Field of View)

    private Camera currentCamera;     // Cam�ra actuellement active

    private void Start()
    {
        // D�sactiver toutes les cam�ras au d�marrage
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Initialiser avec la cam�ra s�lectionn�e
        SwitchCamera(selectedCamera);
    }

    private void Update()
    {
        // V�rifier si la cam�ra s�lectionn�e a chang�
        if (currentCamera != cameras[(int)selectedCamera])
        {
            SwitchCamera(selectedCamera);
        }
    }

    // Fonction pour changer de cam�ra et appliquer la position et le zoom
    private void SwitchCamera(CameraOption newCamera)
    {
        // D�sactiver toutes les cam�ras
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Activer la nouvelle cam�ra
        currentCamera = cameras[(int)newCamera];
        currentCamera.gameObject.SetActive(true);

        // Appliquer la position et le zoom � la cam�ra s�lectionn�e
        currentCamera.transform.position = cameraPositions[(int)newCamera];
        currentCamera.fieldOfView = zoomLevels[(int)newCamera];
    }
}
