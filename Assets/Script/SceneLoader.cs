using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button loadButton;  // Bouton du Canvas
    public string sceneName;   // Nom de la scène à charger

    private void Start()
    {
        // Ajouter l'événement au bouton
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadSelectedScene);
        }
    }

    private void LoadSelectedScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Nom de la scène non défini !");
        }
    }
}
