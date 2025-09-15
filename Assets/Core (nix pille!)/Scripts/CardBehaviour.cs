using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private CardData_SO cardData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<CardList>().ChooseSprite();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
