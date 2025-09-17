using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AudioManaging : MonoBehaviour
{
    #region Fields
    [Header("Volume")]
    [SerializeField]
    [OnChangedCall("MuteSound")]
    private bool mute = false;
    [SerializeField]
    [OnChangedCall("OnVolumeChange")]
    [Range(0.0f, 1.0f)]
    private float globalVolume;
    [SerializeField]
    [OnChangedCall("OnSFXVolumeChange")]
    [Range(0.0f, 1.0f)]
    private float SFXVolume;
    [SerializeField]
    [OnChangedCall("OnMusicVolumeChange")]
    [Range(0.0f, 1.0f)]
    private float musicVolume;
    [Space]
    [Header("Sound Effects")]
    [SerializeField]
    [Tooltip("This should automatically fill up once the game is started.")]
    private AudioSource[] soundEffects;
    [Space]
    [Header("Music")]
    [SerializeField]
    [Tooltip("Insert the music that plays while the main menu is open. Leave blank if no music.")]
    private AudioClip menuMusic;
    [SerializeField]
    [Tooltip("Insert the music for the sorting game gameplay. Leave blank if no music.")]
    private AudioClip sortingGameMusic;
    [SerializeField]
    [Tooltip("Insert the music for the sorting game end state. Leave blank if no music.")]
    private AudioClip sortingGameEndMusic;
    [Space]
    [Header("Camera")]
    [SerializeField]
    [Tooltip("Needed for playing music. Will cause an error if left blank.")]
    private Camera mainCamera;
    #endregion
    #region Properties
    public bool Mute
    {
        get { return mute; }
        set 
        { 
            mute = value;
            MuteSound();
        }
    }
    public float GlobalVolume
    {
        get
        { return globalVolume; }
        set
        {
            //updates the volume only when it is changed
            globalVolume = value;
            OnVolumeChange();
        }
    }

    public float VolumeSFX
    {
        get { return SFXVolume; }
        set
        {
            //updates the volume only when it is changed
            SFXVolume = value;
            OnSFXVolumeChange();
        }
    }

    public float VolumeMusic
    {
        get { return musicVolume; }
        set
        {
            //updates the volume only when it is changed
            musicVolume = value;
            OnMusicVolumeChange();
        }
    }
    #endregion
    #region Methods
    void Awake()
    {
        if (menuMusic != null)
        {
            mainCamera.GetComponent<AudioSource>().clip = menuMusic;
            mainCamera.GetComponent<AudioSource>().Play();
        }
        soundEffects = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        //find all sound effects
        OnVolumeChange();
        OnSFXVolumeChange();
        OnMusicVolumeChange();
    }
    /// <summary>
    /// Select "menu", "sorting gameplay" or "sorting end" to switch music, or "stop" to stop music.
    /// </summary>
    /// <param name="music"></param>
    public void ChangeMusic(string music)
    {
        switch (music)
        {
            case "menu":
                if (menuMusic != null)
                {
                    mainCamera.GetComponent<AudioSource>().clip = menuMusic;
                    mainCamera.GetComponent<AudioSource>().Play();
                }
                else
                {
                    mainCamera.GetComponent<AudioSource>().Stop();
                }
                break;
            case "sorting gameplay":
                if (sortingGameMusic != null)
                {
                    mainCamera.GetComponent<AudioSource>().clip = sortingGameMusic;
                    mainCamera.GetComponent<AudioSource>().Play();
                }
                else
                {
                    mainCamera.GetComponent<AudioSource>().Stop();
                }
                break;
            case "sorting end":
                if (sortingGameEndMusic != null)
                {
                    mainCamera.GetComponent<AudioSource>().clip = sortingGameEndMusic;
                    mainCamera.GetComponent<AudioSource>().Play();
                }
                else
                {
                    mainCamera.GetComponent<AudioSource>().Stop();
                }
                break;
            case "stop":
                mainCamera.GetComponent<AudioSource>().Stop();
                break;
            default:
                Debug.Log("ERROR: The music \"" + music + "\" does not exist");
                break;
        }
    }

    public void MuteSound()
    {
        if(mute) mainCamera.GetComponent<AudioListener>().enabled = false;
        else mainCamera.GetComponent<AudioListener>().enabled = true;
    }

    /// <summary>
    /// For script's own use only, do not use
    /// </summary>
    public void OnVolumeChange()
    {
        AudioListener.volume = globalVolume;
        Debug.Log("Volume changed to " + globalVolume);
    }
    public void OnSFXVolumeChange()
    {
        foreach (AudioSource source in soundEffects)
        {
            if (source.gameObject.tag != "MainCamera")
            {
                source.volume = SFXVolume;
            }
        }
    }
    /// <summary>
    /// For script's own use only, do not use
    /// </summary>
    public void OnMusicVolumeChange()
    {
        mainCamera.GetComponent<AudioSource>().volume = musicVolume;
    }
    #endregion
}

//should probably move this class elsewhere
public class OnChangedCallAttribute : PropertyAttribute
{
    public string methodName;
    public OnChangedCallAttribute(string methodNameNoArguments)
    {
        methodName = methodNameNoArguments;
    }
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(OnChangedCallAttribute))]
public class OnChangedCallAttributePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label);
        if (EditorGUI.EndChangeCheck())
        {
            OnChangedCallAttribute at = attribute as OnChangedCallAttribute;
            MethodInfo method = property.serializedObject.targetObject.GetType().GetMethods().Where(m => m.Name == at.methodName).First();

            if (method != null && method.GetParameters().Count() == 0)// Only instantiate methods with 0 parameters
                method.Invoke(property.serializedObject.targetObject, null);
        }
    }
}

#endif
