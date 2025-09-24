using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class GameBehavior_SO : ScriptableObject
{
    private static List<GameObject> cards = new List<GameObject>();
    private static int playerScore = 0;
    [SerializeField][Tooltip("How much added to the score upon a correct answer.")] private static int addedScore = 1;

    public static int PlayerScore { get => playerScore; }

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

    public static void ResetScore()
    {
        playerScore = 0;
    }

    public static void ConstructList()
    {
        GameObject.FindGameObjectsWithTag("Card", cards);
        int sortingLayer = 0;
        foreach (GameObject card in cards)
        {
            //Debug.Log(card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name);
            //Debug.Log(card.<SpriteRenderer>().sprite.name);
            
            card.GetComponent<SpriteRenderer>().sortingOrder = sortingLayer;
            if (card.transform.GetChild(0).GetComponent<SpriteRenderer>() != null) card.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = sortingLayer + 1;
            if (card.transform.GetChild(0).GetComponent<MeshRenderer>() != null) card.transform.GetChild(0).GetComponent<TextMeshPro>().sortingOrder = sortingLayer + 1;

            card.GetComponent<SwipeInput>().IsActive = false;
            sortingLayer += 2;
        }
    }

    public static void ActivateNextCard()
    {
        if (cards.Count != 0)
        {
            Debug.Log("Card activated");
            cards.Last().GetComponent<SwipeInput>().IsActive = true;
            cards.Remove(cards.Last());
        }
        else
        {
            ToEndScreen();
        }
    }

    private static void ToEndScreen()
    {
        sceneManagingDuringRuntime sceneChanger = GameObject.FindGameObjectWithTag("MenuItem").GetComponent<sceneManagingDuringRuntime>();
        sceneChanger.StartCoroutine(sceneChanger.LoadScenes());
    }
}
