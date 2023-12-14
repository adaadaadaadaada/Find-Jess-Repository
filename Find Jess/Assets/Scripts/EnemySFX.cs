using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;
using static UnityEngine.EventSystems.EventTrigger;

/// <summary>
/// Plays a randomized audio clip from 3 clips every once in a while
/// </summary>

public class EnemySFX : MonoBehaviour
{
    EnemyMovement _enemy;

    private bool _chasingSFXplaying = false;

    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource[] sources;
    private AudioSource growlSource;
    private AudioSource chaseSource;
    public float minWaitBetweenPlays = 5f;
    public float maxWaitBetweenPlays = 15f;
    public float waitTimeCountdown = -1f;

    void Start()
    {
        _enemy = GameObject.Find("Monster").GetComponent<EnemyMovement>();
        sources = GetComponents<AudioSource>();
        Debug.Log("got sources amount" + sources.Length);
        growlSource = sources[0];
        chaseSource = sources[1];
    }

    void Update()
    {
        if (!growlSource.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                currentClip = audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
                growlSource.clip = currentClip;
                growlSource.Play();
                waitTimeCountdown = UnityEngine.Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }

    public void PlayChasingMusic()
    {
        if (!_chasingSFXplaying)
        {
            Debug.Log("playing music");
            chaseSource.Play();
            _chasingSFXplaying = true;
        }
    }
}