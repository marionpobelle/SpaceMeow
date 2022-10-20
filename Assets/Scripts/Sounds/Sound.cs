using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    //Indicate if the sound is a sound effect
    public bool soundEf;

    //Indicate if the sound is music
    public bool music;

    [HideInInspector]
    public AudioSource source;

}
