using UnityEngine;

public class ListBehaviour : MonoBehaviour
{
    [SerializeField] private CardList_SO cardList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cardList.ChooseSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
