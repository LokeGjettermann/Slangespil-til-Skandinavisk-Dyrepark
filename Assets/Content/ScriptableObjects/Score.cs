using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject
{
    public int PlayerScore = 0;


    public void AddToScore()
    {
        PlayerScore++;
        UIDocument HUDDocument = GameObject.Find("GameHUD").GetComponent<UIDocument>();
        HUDDocument.rootVisualElement.Q<Label>("Score_Lbl").text = $"Score: {PlayerScore}";
    }
}
