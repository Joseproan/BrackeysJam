using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvoiramentSounds : MonoBehaviour
{
    [Header("List of AudioClips")]
    [SerializeField] private AudioClip[] sounds;
    [Header("Parameters")]
    [SerializeField] private float minVolume;
    [SerializeField] private float maxVolume;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    [SerializeField] private float minTime, maxTime;

    private AudioSource envoiramentAudio;
    private int totalClips;
    private int currentClip;
    private float timer, randomRangeClip;
    private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        randomRangeClip = Random.Range(minTime, maxTime);
        envoiramentAudio = GetComponent<AudioSource>();
        totalClips = sounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!envoiramentAudio.isPlaying)
        {
            waiting = true;
        }
        if(waiting)
        {
            timer += Time.deltaTime;
        }
        if(timer > randomRangeClip)
        {
            timer = 0;
            randomRangeClip = Random.Range(minTime, maxTime);
            waiting = false;
            RandomPlay();
        }
    }

    public void RandomPlay()
    {
        currentClip = Random.Range(0, totalClips);
        envoiramentAudio.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        envoiramentAudio.volume = UnityEngine.Random.Range(minVolume, maxVolume);
        envoiramentAudio.PlayOneShot(sounds[currentClip]);
    }
}
