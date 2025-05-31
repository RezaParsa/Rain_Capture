using UnityEngine;

public class Soundmanger : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip attackSound;

    private AudioSource _audiosource;
    [SerializeField] private AudioClip _run1SFX;
    [SerializeField] private AudioClip _run2SFX;


    void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    void _Playrun1()
    {
        _audiosource.PlayOneShot(_run1SFX);
    }
    void _Playrun2()
    {
        _audiosource.PlayOneShot(_run2SFX);
    }
}
