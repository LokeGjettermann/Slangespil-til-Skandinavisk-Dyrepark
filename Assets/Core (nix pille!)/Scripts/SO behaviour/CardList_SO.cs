using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList_SO", menuName = "Scriptable Objects/CardList_SO")]
public class CardList_SO : ScriptableObject
{
    public Sprite sprite1;
    public Sprite sprite2;

    public List<Sprite> sprites = new List<Sprite>();
    public List<GameObject> pictureObjects = new List<GameObject>();

}
