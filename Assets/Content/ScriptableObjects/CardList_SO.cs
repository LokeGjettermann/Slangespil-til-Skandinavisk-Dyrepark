using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList_SO", menuName = "Scriptable Objects/CardList_SO")]
public class CardList_SO : ScriptableObject
{
    private List<Sprite> pictures = new List<Sprite>();
    private List<string> text = new List<string>();
    private int number = 0;

    public Sprite sprite1;
    public Sprite sprite2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        number = 0;   
    }

    public Sprite ChooseSprite()
    {
        pictures.Add(sprite1);
        pictures.Add(sprite2);
        Sprite value = pictures[number];
        number++;

        Debug.Log(sprite1);
        Debug.Log(sprite2);

        pictures.Clear();
        return value;
    }
}
