using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void playSound(AudioClip audioClip, Transform spawn, float volume){
        AudioSource audioSource = Instantiate(soundFXObject, spawn.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

        public void playRANDSound(AudioClip[] audioClips, Transform spawn, float volume){
        AudioSource audioSource = Instantiate(soundFXObject, spawn.position, Quaternion.identity);

        Debug.Log(audioClips.Length);
        Debug.Log(audioClips);

        AudioClip audioClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length-1)];

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
