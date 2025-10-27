using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private Slider _slider;
    public AudioClip[] backgroundMusics;
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        if (_audioSource == null)
            _audioSource = FindFirstObjectByType<AudioSource>();
    }

    void Update()
    {
        _audioSource.volume = _slider.value;
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
}
