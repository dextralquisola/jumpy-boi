using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public static BGMScript BgInstance;
    AudioSource myAudioSource;
    public void SetVolume(float volume)
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = volume;
    }

    private void Awake()
    {
        if(BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }
}
