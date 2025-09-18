using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class GameBehavior_SO : ScriptableObject
{
    [SerializeField][Tooltip("How much added to the score upon a correct answer.")] private static int addedScore = 1;
    private static int playerScore = 0;
    private static List<GameObject> cards = new List<GameObject>();

    public static void AddToScore()
    {
        playerScore += addedScore;
        // Finds the game object, gets it's UIDocment, finds the score-label and then updates it.
        GameObject.Find("GameHUD").GetComponent<UIDocument>().rootVisualElement.Q<Label>("Score_Lbl").text = $"Score: {playerScore}";
    }

    public static void ConstructList()
    {
        GameObject.FindGameObjectsWithTag("Card", cards);
        int sortingLayer = 0;
        foreach (GameObject card in cards)
        {
            card.GetComponent<SpriteRenderer>().sortingOrder = sortingLayer;
            sortingLayer--;
            card.GetComponent<SwipeInput>().IsActive = false;
            //card.SetActive(false);
        }
    }

    public static void ActivateNextCard()
    {
        if (cards.Count != 0)
        {
            cards.First().GetComponent<SwipeInput>().IsActive = true; //.SetActive(true);
            cards.Remove(cards.First());
        }
    }
}
