using System.Linq;
using UnityEngine;

public class EnemyWalkSFX : MonoBehaviour
{
    // sfdtr
    public EnemyMovement enemy;
    public GroundCheck groundCheck;

    [Header("Step")]
    public AudioSource stepAudio;
    [Tooltip("Minimum velocity for moving audio to play")]
    /// <summary> "Minimum velocity for moving audio to play" </summary>
    public float velocityThreshold = .01f;
    Vector2 lastEnemyPosition;
    Vector2 CurrentEnemyPosition => new Vector2(enemy.transform.position.x, enemy.transform.position.z);

    AudioSource[] MovingAudios => new AudioSource[] { stepAudio };


    void Reset()
    {
        // Setup stuff.
        enemy = GetComponentInParent<EnemyMovement>();
        groundCheck = (transform.parent ?? transform).GetComponentInChildren<GroundCheck>();
        stepAudio = GetOrCreateAudioSource("Step Audio");
    }

    void FixedUpdate()
    {
        // Play moving audio if the enemy is moving and on the ground.
        float velocity = Vector3.Distance(CurrentEnemyPosition, lastEnemyPosition);
        if (velocity >= velocityThreshold && groundCheck && groundCheck.isGrounded)
        {
            SetPlayingMovingAudio(stepAudio);
        }
        else
        {
            SetPlayingMovingAudio(null);
        }

        // Remember lastEnemyPosition.
        lastEnemyPosition = CurrentEnemyPosition;
    }


    /// <summary>
    /// Pause all MovingAudios and enforce play on audioToPlay.
    /// </summary>
    /// <param name="audioToPlay">Audio that should be playing.</param>
    void SetPlayingMovingAudio(AudioSource audioToPlay)
    {
        // Pause all MovingAudios.
        foreach (var audio in MovingAudios.Where(audio => audio != audioToPlay && audio != null))
        {
            audio.Pause();
        }

        // Play audioToPlay if it was not playing.
        if (audioToPlay && !audioToPlay.isPlaying)
        {
            audioToPlay.Play();
        }
    }


    #region Utility.
    /// <summary>
    /// Get an existing AudioSource from a name or create one if it was not found.
    /// </summary>
    /// <param name="name">Name of the AudioSource to search for.</param>
    /// <returns>The created AudioSource.</returns>
    AudioSource GetOrCreateAudioSource(string name)
    {
        // Try to get the audiosource.
        AudioSource result = System.Array.Find(GetComponentsInChildren<AudioSource>(), a => a.name == name);
        if (result)
            return result;

        // Audiosource does not exist, create it.
        result = new GameObject(name).AddComponent<AudioSource>();
        result.spatialBlend = 1;
        result.playOnAwake = false;
        result.transform.SetParent(transform, false);
        return result;
    }

    static void PlayRandomClip(AudioSource audio, AudioClip[] clips)
    {
        if (!audio || clips.Length <= 0)
            return;

        // Get a random clip. If possible, make sure that it's not the same as the clip that is already on the audiosource.
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        if (clips.Length > 1)
            while (clip == audio.clip)
                clip = clips[Random.Range(0, clips.Length)];

        // Play the clip.
        audio.clip = clip;
        audio.Play();
    }
    #endregion 
}
