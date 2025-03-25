using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    
    public AudioSource sfxSource;
    public AudioSource AmbienceSource;

    [Header("Audio Clips")]
    public AudioClip introClip;     
    public AudioClip ambientClip_level1;
    public AudioClip ambientClip_level2;
    public AudioClip winClip;
    public AudioClip gameOverClip;
    public AudioClip kongClip;

    public AudioClip jumpClip;
    public AudioClip loseLifeClip;
    public AudioClip jumpOverClip; 
    public AudioClip getCoinClip; 
    public AudioClip getItemClip; 
    public AudioClip powerUpClip; 
    public AudioClip powerDownClip; 
    public AudioClip stageClearClip; 
    public AudioClip pauseClip; 



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        Debug.Log("Starting Ambient Sound: " + (ambientClip_level1 != null ? "Clip Found" : "Clip Missing"));
        PlayAmbientSound();
    }
    
    public void PlayAmbientSound()
    {
        if (AmbienceSource == null)
        {
            Debug.LogError("AmbienceSource is NULL!");
            return;
        }
        else if (ambientClip_level1 == null)
        {
            Debug.LogError("ambientClip_level1 is NULL!");
            return;
        }
        AmbienceSource.clip = ambientClip_level1;
        AmbienceSource.loop = true;
        AmbienceSource.Play();
        Debug.Log("Ambient Sound Playing...");
    }

    public void PlaySound (AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
