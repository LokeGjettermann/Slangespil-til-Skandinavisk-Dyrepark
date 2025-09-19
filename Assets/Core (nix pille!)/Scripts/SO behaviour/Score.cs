using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject
{
    [SerializeField][Tooltip("How much added to the score upon a correct answer.")] private int addedScore = 1;
    private int playerScore = 0;

    public void AddToScore()
    {
        playerScore += addedScore;
        // Finds the game object, gets it's UIDocment, finds the score-label and then updates it.
        GameObject.Find("GameHUD").GetComponent<UIDocument>().rootVisualElement.Q<Label>("Score_Lbl").text = $"Score: {playerScore}";
    }
}
