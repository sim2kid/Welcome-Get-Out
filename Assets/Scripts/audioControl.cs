using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource src;
    static bool hasPlayed;
    void Start()
    {
        src = this.GetComponent<AudioSource>();
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        hasPlayed = false;
    }
    
    //will only play once per update max
    private static void playSound(string snd)
    {
        if (!hasPlayed)
        {
            src.clip = (AudioClip)Resources.Load(snd);
            src.Play();
            hasPlayed = true;
        }
    }

    //will override other sounds
    private static void playImportantSound(string snd)
    {
            src.clip = (AudioClip)Resources.Load(snd);
            src.Play();
            hasPlayed = true;
    }
    public static void playTestSound() {
        playSound("crow");
    }
    //a new public method should be added for each sound file, calling one of the private existing methods
}