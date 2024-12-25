using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect
{
    jump,
    death,
    addItem1,
    addItem2,
    finish,
    saw,
    boxJump,
    movingPlatform,
    trampoline,
    button
}
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] GameObject prefab;
    [SerializeField] List<AudioClip> shortSounds;
    AudioSource[] audioSounds;

    bool stop;

    public static AudioController instance;
    void Awake()
    {
        instance = this;
    }
    public void SetAudio()
    {
        PlayerPrefs.SetFloat("Index_Sound_Bg", backgroundMusic.time);
    }
    // Start is called before the first frame update
    void Start()
    {
        stop = PlayerPrefs.GetInt("Audio", 0) != 0 ? false : true;
        if (!stop)
        {
            backgroundMusic.time = PlayerPrefs.GetFloat("Index_Sound_Bg", 0);
            backgroundMusic.Play();
        }
        audioSounds = new AudioSource[shortSounds.Count];
        for(int i = 0; i < shortSounds.Count; i++)
        {
            audioSounds[i] = new AudioSource();
        }
    }

    public void PlaySound(int i = 1, float volume = 1f, bool isLoopback = false, bool repeat = true)
    {
        Play(shortSounds[i], ref audioSounds[i], volume, isLoopback, repeat);
    }

    void Play(AudioClip clip, ref AudioSource audioSource, float volume = 1f, bool isLoopback = false, bool repeat = false)
    {
        if (audioSource != null && audioSource.isPlaying && !repeat)
            return;
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
