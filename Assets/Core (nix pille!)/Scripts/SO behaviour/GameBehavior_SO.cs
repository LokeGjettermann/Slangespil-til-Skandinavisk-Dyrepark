using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
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
        try
        {
            GameObject.Find("GameHUD").GetComponent<UIDocument>().rootVisualElement.Q<Label>("Score_Lbl").text = $"Score: {playerScore}";
        }
        catch
        {

        }
    }

    public static void ConstructList()
    {
        GameObject.FindGameObjectsWithTag("Card", cards);
        int sortingLayer = 0;
        foreach (GameObject card in cards)
        {
            card.GetComponent<SpriteRenderer>().sortingOrder = sortingLayer;
            if (card.GetComponentInChildren<SpriteRenderer>() != null) card.GetComponentInChildren<SpriteRenderer>().sortingOrder = sortingLayer + 1;
            if (card.GetComponentInChildren<MeshRenderer>() != null) card.GetComponentInChildren<SortingGroup>().sortingOrder = sortingLayer + 1;
            card.GetComponent<SwipeInput>().IsActive = false;
            sortingLayer -= 2;
        }
    }

    public static void ActivateNextCard()
    {
        if (cards.Count != 0)
        {
            cards.First().GetComponent<SwipeInput>().IsActive = true;
            cards.Remove(cards.First());
        }
    }
}
