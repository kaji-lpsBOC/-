using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject Ans_maru;
    public GameObject Ans_batsu;
    public GameObject Bgm;
    public GameObject Clear;

    public AudioClip maru;
    public AudioClip batsu;
    public AudioClip bgm;
    public AudioClip clear;
    AudioSource audioSource;


    public void sound_bgm()
    {
        audioSource = Bgm.GetComponent<AudioSource>();
        audioSource.PlayOneShot(bgm);
        
    }
    public void sound_maru()
    {
        audioSource = Ans_maru.GetComponent<AudioSource>();
        audioSource.PlayOneShot(maru);
    }

    public void sound_batsu()
    {
        audioSource = Ans_batsu.GetComponent<AudioSource>();
        audioSource.PlayOneShot(batsu);
    }

    public void sound_clear()
    {
        audioSource = Clear.GetComponent<AudioSource>();
        audioSource.PlayOneShot(clear);
    }
}
