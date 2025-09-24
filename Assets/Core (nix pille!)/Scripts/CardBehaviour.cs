using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private CardData_SO cardData;
    private bool hasText;

    void Awake()
    {
        hasText = !cardData.IsPictureCard;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
