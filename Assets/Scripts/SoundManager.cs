using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Play all sounds
public class SoundManager : MonoBehaviour
{
    public AudioSource bgmAS;
    public AudioSource effAS;

    public List<AudioClip> bgmAudioClips = new List<AudioClip>();
    public List<AudioClip> explosionAudioclips = new List<AudioClip>();
    public List<AudioClip> itemAudioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
