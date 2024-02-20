using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    AudioSource source;

    public AudioClip lvl1Music;
    
    // Start is called before the first frame update
    void Start()
    {
        source.clip = lvl1Music;
        source.Play();
        source.Stop();
    }

    // Update is called once per frame
    void Awake()
    {
        source = GetComponent<AudioSource>();

    }
}
