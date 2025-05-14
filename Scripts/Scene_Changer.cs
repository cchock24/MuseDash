using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string sceneToLoad; 

void Start()
    {

    }
    public void LoadScene()
    {   
        Debug.Log("Button clicked, attempting to load scene: " + sceneToLoad);
        try
        {
            // Attempt to load the scene
            SceneManager.LoadScene(sceneToLoad);
        }
        // If scene doesn't load error message
        catch (System.Exception e)
        {
            Debug.LogError("Error loading scene: " + e.Message);
        }
    }
}
