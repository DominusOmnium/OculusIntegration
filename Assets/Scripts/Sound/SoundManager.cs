using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    private Dictionary<string, AudioClip> _audioClips;
    [SerializeField] private AudioSource _source;
    [SerializeField] private SoundData _soundData;
    public float timeBetweenShots = 1.75f;
    float timer = 0;
    public static SoundManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            // Do not modify _instance here. It will be assigned in awake
            return new GameObject("(singleton) SoundManager").AddComponent<SoundManager>();
        }
    }
    
    
    
    // public static void PlayMusic(string name)
    // {
    //     try
    //     {
    //         if (Instance._audioClips.ContainsKey(name))
    //         {
    //             Instance._source.clip = Instance._audioClips[name];
    //             Instance._source.Play();
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw new SystemException( "Sound not loaded");
    //     }
    //   
    // }
    public static void PlayMusicOnLoad(string name)
    { 
        Instance.StartCoroutine(Instance.LoadSound(name));
        Debug.Log(Instance._audioClips.ContainsKey(name));
        if (Instance._audioClips.ContainsKey(name))
        {
            Instance._source.clip = Instance._audioClips[name];
            Instance._source.Play();
        }
    }

    void Awake()
    {
        // Only one instance of SoundManager at a time!
        _audioClips = new Dictionary<string, AudioClip>();
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        
        var soundList = Resources.LoadAll("Sounds/");
        foreach (var obj in soundList)
        {
            _audioClips.Add(obj.name, (AudioClip)obj);
        }
    }
    
    private IEnumerator LoadSound(string soundFileName)
    {
        if (!_audioClips.ContainsKey(soundFileName))
        {
            _audioClips.Add(soundFileName, null);
            ResourceRequest request = Resources.LoadAsync<AudioClip>("Sounds/" + soundFileName);
            while (!request.isDone)
            {
                yield return null;
            }
            AudioClip soundClip = (AudioClip) request.asset;
            if (null == soundClip)
            {
                Debug.Log("Sound not loaded: " + soundFileName);
            }
            _audioClips[soundFileName] = soundClip;
        }
    }

    public void PlaySound(string soundFileName, AudioSource source)
    {
        source.clip = _audioClips[soundFileName];
        source.Play();

    }
    public void PlaySoundLoop(string soundFileName, AudioSource source)
    {
        source.clip = _audioClips[soundFileName];
        source.loop = true;
        source.Play();
    }

    public void StopSoundLoop(AudioSource source)
    {
        source.Stop();
    }
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        SoundManager.PlayLoop("BackgroundAmbientLab", _source);
            
    }

    public static  void Play(string soundFileName, AudioSource source)
    {
        source.clip = Instance._audioClips[soundFileName];
        source.Play();
    }
    public static void PlayLoop(string soundFileName, AudioSource source)
    {
        source.clip = Instance._audioClips[soundFileName];
        source.loop = true;
        source.Play();
    }
}
