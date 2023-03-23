using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viktorAudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip thunderStrike;


    public static viktorAudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
