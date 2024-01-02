using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("======Audio Source=====")]
    [SerializeField] AudioSource SFXSource;

    [Header("======Audio Clip=====")]
    public AudioClip coinpickup;
    public AudioClip alert;
    public AudioClip rightanswer;
    public AudioClip wronganswer;
    public AudioClip hitpeople;
    public AudioClip speedup;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
