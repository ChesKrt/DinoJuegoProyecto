using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private Slider _slider;
    public AudioClip[] backgroundMusics;
    public AudioClip[] soundEffects;
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        if (_audioSource == null)
            _audioSource = FindFirstObjectByType<AudioSource>();


        _audioSource.volume = PlayerPrefs.GetFloat(ConstanceJson.VOLUME, 1);
    }

    private void Update()
    {
        _slider.value = _audioSource.volume;
    }

    public void ApplyChange()
    {
        _audioSource.volume = _slider.value;
        PlayerPrefs.SetFloat(ConstanceJson.VOLUME, _slider.value);
    }
    
    public void PlayBackgroundMusic(int index)
    {
        _audioSource.clip = backgroundMusics[index];
        _audioSource.Play();
    }

    public void StopBackgroundMusic(int index)
    {
        _audioSource.clip = backgroundMusics[index];
        _audioSource.Stop();
    }

    public void PlayClip(int index)
    {
        _audioSource.PlayOneShot(soundEffects[index]);
    }
}
