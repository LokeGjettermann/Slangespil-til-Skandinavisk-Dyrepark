using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    private List<Sprite> pictures;
    private List<string> text;
    private int number;

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pictures = new List<Sprite>();
        text = new List<string>();
        number = 0;

        pictures.Add(sprite1);
        pictures.Add(sprite2);
    }

    public Sprite ChooseSprite()
    {
        Sprite value = pictures[number];
        number++;
        return value;
    }
}
