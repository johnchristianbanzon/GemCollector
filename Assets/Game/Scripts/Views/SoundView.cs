using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundView : MonoBehaviour
{
    [SerializeField]
    private AudioSource _bgmSource;
    [SerializeField]
    private AudioSource _sfxSource;
    [Inject]
    private SoundManager _soundManager;
    private Dictionary<string, AudioClip> _soundDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        _soundManager.SetView(this);
        _soundManager.PlayMenuBGM();
    }

    public void PlayBgm(string gameBgm)
    {
        _bgmSource.clip = LoadResource(gameBgm);
        _bgmSource.Play();
    }

    public void PlaySFX(string gameSfx)
    {
        _sfxSource.clip = LoadResource(gameSfx);
        _sfxSource.Play();
    }

    private AudioClip LoadResource(string bgm)
    {
        if (_soundDictionary.ContainsKey(bgm))
        {
            return _soundDictionary[bgm];
        }
        var resourcesClip = (AudioClip)Resources.Load("Audio/" + bgm);
        _soundDictionary.Add(bgm, resourcesClip);
        return resourcesClip;
    }
}
