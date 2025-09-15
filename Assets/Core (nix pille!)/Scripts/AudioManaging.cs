using System.Collections.Generic;
using UnityEngine;

public class AudioManaging : MonoBehaviour
{
    #region Fields
    [Header("(Will not change the volume if changed during the game)")]
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float globalVolume;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float SFXVolume;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float musicVolume;
    [SerializeField]
    private List<AudioSource> soundEffects=new List<AudioSource>();
    #endregion
    #region Properties
    public float Volume
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
    #endregion
    #region Methods
    void Awake()
    {
        //soundEffects.Add()
        //find all sound effects
        OnVolumeChange();
        OnSFXVolumeChange();
        OnMusicVolumeChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVolumeChange()
    {
        AudioListener.volume = globalVolume;
        Debug.Log("Volume changed to " + globalVolume);
    }
    void OnSFXVolumeChange()
    {

    }
    void OnMusicVolumeChange()
    {

    }
    #endregion
}
