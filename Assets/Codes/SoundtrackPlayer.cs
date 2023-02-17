using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackPlayer : MonoBehaviour
{
    public AudioClip[] Soundtracks;
    AudioSource AS;

    void Start()
    {
        AS= GetComponent<AudioSource>();
    }

   void Update()
    {
        if(AS.isPlaying == false)
        {
        AS.clip =Soundtracks[Random.Range(0, 2)];
        AS.Play();
        }
    }
}
