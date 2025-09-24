using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList_SO", menuName = "Scriptable Objects/CardList_SO")]
public class CardList_SO : ScriptableObject
{
    //public Sprite sprite1;
    //public Sprite cardBackgroundSprite;

    public List<ScriptableObject> cardDataList = new List<ScriptableObject>();
    private List<Sprite> sprites = new List<Sprite>();
    private List<GameObject> pictureObjects = new List<GameObject>();
    public List<Sprite> Sprites { get => sprites; set => sprites = value; }
    public List<GameObject> PictureObjects { get => pictureObjects; set => pictureObjects = value; }


}
