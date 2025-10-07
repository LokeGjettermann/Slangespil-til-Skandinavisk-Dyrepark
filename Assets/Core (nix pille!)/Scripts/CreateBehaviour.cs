using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreateBehaviour : MonoBehaviour
{
    public GameObject pictureCardPrefab;
    public GameObject factCardPrefab;
    public CardList_SO cardList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the value of the card list object & set it to the prefab's scoring
        cardList.Sprites.Clear();
        cardList.PictureObjects.Clear();
        //check that the card list is not empty (give an error if it is)
        if (cardList.cardDataList.Count <= 0 || cardList.cardDataList == null)
        {
            Debug.Log("ERROR: CardList.CardData is empty");
            return;
        }
        CardData_SO currentCard = cardList.cardDataList[0] as CardData_SO;
        //instantiate the first in the list at (-5, 0, 0)
        if (currentCard.IsPictureCard)
        {
            GameObject card = Instantiate(pictureCardPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
            card.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = currentCard.Sprite;
            card.GetComponent<Scoring>().GivenSnakeType = currentCard.TypeOfSnake;
        }
        else
        {
            GameObject card = Instantiate(factCardPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
            if (ScriptableObject.FindFirstObjectByType<SetLanguage>() != null && ScriptableObject.FindFirstObjectByType<SetLanguage>().language == SetLanguage.Language.Dansk) card.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = currentCard.CardTextDanish;
            else card.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = currentCard.CardTextEnglish;
            card.GetComponent<Scoring>().GivenSnakeType = currentCard.TypeOfSnake;
        }
        
        //instantiate all others at (5, 0, 0)
        for (int i = 1; i < cardList.cardDataList.Count; i++)
        {
            CardData_SO cardData = cardList.cardDataList[i] as CardData_SO;
            if (cardData.IsPictureCard)
            {
                GameObject card = Instantiate(pictureCardPrefab, new Vector3(5, 0, 0), Quaternion.identity);
                card.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = cardData.Sprite;
                card.GetComponent<Scoring>().GivenSnakeType = cardData.TypeOfSnake;
            }
            else
            {
                GameObject card = Instantiate(factCardPrefab, new Vector3(5, 0, 0), Quaternion.identity);
                if (ScriptableObject.FindFirstObjectByType<SetLanguage>() != null && ScriptableObject.FindFirstObjectByType<SetLanguage>().language == SetLanguage.Language.Dansk) card.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = cardData.CardTextDanish;
                else card.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = cardData.CardTextEnglish;
                card.GetComponent<Scoring>().GivenSnakeType = cardData.TypeOfSnake;
            }
        }

        //cardList.sprites.Add(cardList.cardBackgroundSprite);
        /*
        GameObject.FindGameObjectsWithTag("Picture", cardList.pictureObjects);

        for (int i = 0; i < cardList.pictureObjects.Count; i++)
        {
            cardList.pictureObjects[i].GetComponent<SpriteRenderer>().sprite = cardList.sprites[i];
        }
        */
        GameBehavior_SO.ConstructList();
        GameBehavior_SO.ActivateNextCard();
    }


}
