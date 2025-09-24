using UnityEngine;

public enum SnakeType
{
    Snog = 0,
    Hugorm = 1,
}

public class Scoring : MonoBehaviour
{
    [SerializeField] private SnakeType snakeType;

    public SnakeType GivenSnakeType { get => snakeType; set => snakeType = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
            Debug.Log("you got it right.");
            GameBehavior_SO.AddToScore();
        }
    }
}
