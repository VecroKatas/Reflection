using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<MusicClipData> _clipDatas = new List<MusicClipData>();

    private List<MusicClipData> _clipsHistory = new List<MusicClipData>();
    
    private MusicClipData _currentClipData;
    private int _currentClipIndex = -1;

    public Action<MusicClipData> ClipChanged;
        
    private void Start()
    {
        PlayNewClip();
    }

    private void PlayNewClip()
    {
        _currentClipData = GetNewClip();
        
        _clipsHistory.Add(_currentClipData);

        _currentClipIndex++;
        
        PlayClipByCurrentIndex();
    }

    private void PlayClipByCurrentIndex()
    {
        _audioSource.Pause();
        
        _currentClipData = _clipsHistory[_currentClipIndex];
        _audioSource.clip = _currentClipData.Music;
        _audioSource.Play();
        
        ClipChanged.Invoke(_currentClipData);
    }

    private MusicClipData GetNewClip()
    {
        return _clipDatas[Random.Range(0, _clipDatas.Count - 1)];
    }

    public void TogglePause()
    {
        if (_audioSource.isPlaying)
            _audioSource.Pause();
        else
            _audioSource.UnPause();
    }

    public void PlayPrevious()
    {
        if (_currentClipIndex > 0)
        {
            _currentClipIndex--;
        }
        PlayClipByCurrentIndex();
    }
    
    public void PlayNext()
    {
        if (_currentClipIndex < _clipsHistory.Count - 2)
        {
            _currentClipIndex++;
            PlayClipByCurrentIndex();
        }
        else
        {
            PlayNewClip();
        }
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
