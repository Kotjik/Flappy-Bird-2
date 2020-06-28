using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource collide;
    private AudioSource scale;
    private AudioSource life;
    private AudioSource invulnerable;
    private AudioSource speedDown;
    private AudioSource speedUp;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        collide = sounds[0];
        scale = sounds[1];
        life = sounds[2];
        invulnerable = sounds[3];
        speedDown = sounds[4];
        speedUp = sounds[5];
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

    public void PlayLife()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            life.Play();
        }
    }

    public void PlayInvulnerable()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            invulnerable.Play();
        }
    }

    public void PlaySpeedDown()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            speedDown.Play();
        }
    }

    public void PlaySpeedUp()
    {
        if (!PlayerPrefs.HasKey("soundBool") || PlayerPrefs.GetInt("soundBool") == 1)
        {
            speedUp.Play();
        }
    }
}
