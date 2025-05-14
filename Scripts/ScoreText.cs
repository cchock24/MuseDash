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
        //Set the text for the end screen
        comboText.text = "Max Combo: " + getHighestCombo();
        hitText.text = "Hit: " + Song_Manager.notesHit;
        missText.text = "Missed: " + Song_Manager.notesMissed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Get Highest Combo
    public int getHighestCombo(){
        int biggest = 0;
        foreach(int i in Song_Manager.combos){
            if(i > biggest){
                biggest = i;
            }
        }
        return biggest;
    }
}
