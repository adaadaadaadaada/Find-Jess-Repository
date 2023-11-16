using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays a randomized audio clip from 3 clips every once in a while
/// </summary>

public class JessSFX : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWaitBetweenPlays = 7f;
    public float maxWaitBetweenPlays = 17f;
    public float waitTimeCountdown = -1f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                currentClip = audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
                source.clip = currentClip;
                source.Play();
                waitTimeCountdown = UnityEngine.Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}