using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI missText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comboText.text = "Combo: " + Song_Manager.combo;
        hitText.text = "Hit: " + Song_Manager.notesHit;
        missText.text = "Missed: " + Song_Manager.notesMissed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
