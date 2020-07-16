using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [System.Serializable]
    struct AudioLibrary{
        public string name;
        public AudioClip clip;
    }

    [SerializeField] private List<AudioLibrary> bgmClips;
    [SerializeField] private List <AudioLibrary> sfxClips;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    public static AudioManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }

    public void PlaySFX(string name)
    {
        if (sfxClips.Any(e => e.name == name))
        {
            sfxSource.PlayOneShot(sfxClips.First(e => e.name == name).clip);
        } else
        {
            print(name + " Clip doesn't exist!");
        }
    }

    public void PlayBGM(string name)
    {
        if (bgmClips.Any(e => e.name == name))
        {
            bgmSource.loop = true;
            bgmSource.clip = bgmClips.First(e => e.name == name).clip;
            bgmSource.Play();
        } else
        {
            print(name+" Clip doesn't exist!");
        }
    }
}
