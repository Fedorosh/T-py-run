using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;

    public static bool IsSound => AudioListener.pause;
    void Start()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
