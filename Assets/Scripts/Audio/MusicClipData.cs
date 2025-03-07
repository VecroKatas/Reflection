using UnityEngine;

[CreateAssetMenu(fileName = "Music Clip Data", menuName = "MusicClipData")]
public class MusicClipData : ScriptableObject
{
    public AudioClip Music;
    public string Name;
    public string Author;
}
