using UnityEngine;
using UnityEngine.SceneManagement;

public class getValue : MonoBehaviour
{
    public string songFileName;
    public string up;
    public string down;

    public void OnSongSelected()
    {
        //Static Variables to pass among different scenes
        StaticData.song = songFileName;
        StaticData.upMap = up;
        StaticData.downMap = down;
        SceneManager.LoadScene("SongScreen"); // Replace with your scene name
    }
}
