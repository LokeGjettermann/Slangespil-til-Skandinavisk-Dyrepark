using UnityEngine;

public enum SnakeType
{
    Snog = 0,
    Hugorm = 1,
}

public class Scoring : MonoBehaviour
{
    private Score score;
    [SerializeField] private SnakeType snakeType = SnakeType.Snog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = ScriptableObject.CreateInstance<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Answer(SnakeType snakeType)
    {
        Debug.Log($"You answered {snakeType}, the correct answer was {this.snakeType}.");
        if (snakeType == this.snakeType)
        {
            score.PlayerScore++;
        }
    }
}
