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

    [SerializeField] private AudioSource chasingSFX;

    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWaitBetweenPlays = 5f;
    public float maxWaitBetweenPlays = 15f;
    public float waitTimeCountdown = -1f;

    void Start()
    {
        _enemy = GameObject.Find("Monster").GetComponent<EnemyMovement>();
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
        UpdateChasingMusic();
    }

    void UpdateChasingMusic()
    {
        // jos enemy caughtplayer = true play sound

        if (_enemy.m_CaughtPlayer == true)
        {
            chasingSFX.Play();
        }
    }
}