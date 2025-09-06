using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip tapClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip crackEggClip;
    private bool hasPlayEffectSound = false; 
    public bool hasPlayEffect()
    {
        return hasPlayEffectSound;
    }
    public void SetHasPlayEffect(bool value)
    {
        hasPlayEffectSound = value;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        effectSource.Stop();
        hasPlayEffectSound = true;
    }

    // Update is called once per frame
   public void PlayJump()
    {
        effectSource.PlayOneShot(jumpClip);
    }
    public void PlayTap()
    {
        effectSource.PlayOneShot(tapClip);
    }
    public void PlayHurt()
    {
        effectSource.PlayOneShot(hurtClip);
    }
    public void PlayCrackEgg()
    {
        effectSource.PlayOneShot(crackEggClip);
    }
}
