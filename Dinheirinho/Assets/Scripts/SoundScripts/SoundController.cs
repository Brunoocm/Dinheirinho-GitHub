using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioListener audioListener;
    public AudioSource audioSource;

    public void MutaAudio (bool valor){
        audioListener.enabled = valor;
    }
    public void MutaMusica (bool valor){
        if(valor == false) {
            audioSource.volume = 0;
        } else audioSource.volume = 0.3f;
    }
}
