using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<MusicClipData> _clipDatas = new List<MusicClipData>();
        
    private void Start()
    {
        _audioSource.clip = _clipDatas[Random.Range(0, _clipDatas.Count - 1)].Music;
        _audioSource.Play();
    }
}
