using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource collide;
    private AudioSource scale;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        collide = sounds[0];
        scale = sounds[1];
    }

    public void PlayCollision()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            collide.Play();
        }
    }

    public void PlayScale()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            scale.Play();
        }
    }
}
