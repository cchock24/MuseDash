using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string sceneToLoad; 

void Start()
    {
        Debug.Log("SceneButton script attached and running.");
    }
    public void LoadScene()
    {
        Debug.Log("Button clicked, attempting to load scene: " + sceneToLoad);
        try
        {
            // Attempt to load the scene
            SceneManager.LoadScene(sceneToLoad);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading scene: " + e.Message);
        }
    }
}
