using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    //List of sounds
    public Sound[] sounds;

    public static AudioManager instance;

    //Different categories of sound
    public AudioMixerGroup mainMixer;
    public AudioMixerGroup seMixer;

    public AudioMixerGroup musicMixer;

    /***
    Awake is called when the script instance is being loaded.
    ***/
    void Awake()
    {
        if(instance == null) instance = this;
        else{
            Destroy(gameObject);
            return;
        }
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //Divide sounds between categories for the sliders
            if(s.soundEf == true) s.source.outputAudioMixerGroup = seMixer;
            else if(s.music == true) s.source.outputAudioMixerGroup = musicMixer;
            else s.source.outputAudioMixerGroup = mainMixer;
        }
    }

    /***
    Plays the clip.
    ***/
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    /***
    Pauses the clip.
    ***/
    public void Pause(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    /***
    Unpauses the clip.
    ***/
    public void UnPause(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }

    /***
    Stops the clip.
    ***/
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    /***
    Checks if the clip is playing.
    ***/
    public bool isPlaying(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    /***
    Plays the clip.
    AudioSource.PlayOneShot does not cancel clips that are already being played by AudioSource.PlayOneShot and AudioSource.Play.
    ***/
    public void PlayOneShot(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
}
