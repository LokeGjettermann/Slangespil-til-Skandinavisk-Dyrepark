using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SetLanguage_SO", menuName = "Scriptable Objects/SetLanguage_SO")]
public class SetLanguage : ScriptableObject
{
    public enum Language { Dansk, English}
    [SerializeField]
    private Language currentLanguage;
    public Language language { get => currentLanguage; private set => currentLanguage = value; }

    public void ChangeLanguage(Language language)
    {
        this.language = language;
    }
}
