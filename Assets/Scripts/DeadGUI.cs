using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadGUI : MonoBehaviour{
    public AudioSource audioSource;
    public AudioClip gg;
    public AudioClip pogrzebKota;
    public AudioSource background;

    private void Start(){
        background.Stop();
        audioSource.clip = gg;
        audioSource.Play();
        StartCoroutine(Waiter());
    }
    
    IEnumerator Waiter(){
        yield return  new WaitForSecondsRealtime(audioSource.clip.length);
        audioSource.clip = pogrzebKota;
        audioSource.Play();
    }

    public void GoToMenu(){
        SceneManager.LoadScene(0);
    }
}

