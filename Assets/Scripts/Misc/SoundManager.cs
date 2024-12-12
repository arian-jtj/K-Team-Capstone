using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {  get; private set; }
    private AudioSource sound;

    private AudioClip currentSound;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(AudioClip _sound)
    {
        if (sound.isPlaying && _sound == sound.clip)
            return;

        sound.clip = _sound;
        sound.Play();
    }

    public void StopSound()
    {
        if (sound.isPlaying)
        {
            sound.Stop();
        }
    }

}
