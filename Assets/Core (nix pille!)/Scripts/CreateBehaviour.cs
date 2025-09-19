using Unity.VisualScripting;
using UnityEngine;

public class CreateBehaviour : MonoBehaviour
{
    public GameObject myPrefab;
    public CardList_SO cardList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardList.sprites.Clear();
        cardList.pictureObjects.Clear();

        Instantiate(myPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        
        cardList.sprites.Add(cardList.sprite1);
        cardList.sprites.Add(cardList.sprite2);

        GameObject.FindGameObjectsWithTag("Picture", cardList.pictureObjects);

        for (int i = 0; i < cardList.pictureObjects.Count; i++)
        {
            cardList.pictureObjects[i].GetComponent<SpriteRenderer>().sprite = cardList.sprites[i];
            cardList.pictureObjects[i].GetComponentInParent<SwipeInput>().PictureObject = cardList.pictureObjects[i];
        }

        GameBehavior_SO.ConstructList();
        GameBehavior_SO.ActivateNextCard();
    }

   
}
