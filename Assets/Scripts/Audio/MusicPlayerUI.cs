using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerUI : MonoBehaviour
{
    [SerializeField] private MusicPlayer _musicPlayer;
    
    [SerializeField] private Animator _leftPanelAnimator;
    [SerializeField] private Animator _rightPanelAnimator;

    [SerializeField] private TextMeshProUGUI _clipNameText;
    [SerializeField] private TextMeshProUGUI _authorNameText;
    [SerializeField] private Scrollbar _volumeScrollbar;

    private bool isVolumeDropped = false;
    private bool isCourutinePlaying = false;
    private bool isMouseHovering = false;
    private bool isDown = false;

    private void Awake()
    {
        _musicPlayer.ClipChanged += (clip) => StartCoroutine(ClipChangedAnimation(clip));
    }

    private void ClipChanged(MusicClipData clip)
    {
        _clipNameText.text = clip.Name;
        _authorNameText.text = clip.Author;
    }

    IEnumerator ClipChangedAnimation(MusicClipData clip)
    {
        if (!isDown)
        {
            isCourutinePlaying = true;
            yield return new WaitForSeconds(2);

            LeftDropDown();
            ClipChanged(clip);

            yield return new WaitForSeconds(6);
            isCourutinePlaying = false;
            LeftDrawUp();
        }
        else
        {
            ClipChanged(clip);
        }
    }

    public void PlayPrevious()
    {
        _musicPlayer.PlayPrevious();
    }
    
    public void TogglePause()
    {
        _musicPlayer.TogglePause();
    }
    
    public void PlayNext()
    {
        _musicPlayer.PlayNext();
    }

    public void CahngeVolume()
    {
        _musicPlayer.SetVolume(_volumeScrollbar.value);
    }

    public void MouseLeftDropDown()
    {
        isMouseHovering = true;
        LeftDropDown();
    }
    
    public void MouseLeftDrawUp()
    {
        isMouseHovering = false;
        LeftDrawUp();
    }
    
    public void LeftDropDown()
    {
        if (!isDown && (isCourutinePlaying || isMouseHovering))
        {
            isDown = true;
            _leftPanelAnimator.SetTrigger("DropDown");
        }
    }
    
    public void LeftDrawUp()
    {
        if (isDown && !isCourutinePlaying && !isMouseHovering)
        {
            isDown = false;
            _leftPanelAnimator.SetTrigger("DrawUp");
        }
    }
    
    public void RightSlideIn()
    {
        _rightPanelAnimator.SetTrigger("SlideIn");
    }
    
    public void RightSlideOut()
    {
        _rightPanelAnimator.SetTrigger("SlideOut");
        
        if (isVolumeDropped)
            VolumeToggle();
    }

    public void VolumeToggle()
    {
        if (!isVolumeDropped)
        {
            VolumeDropDown();
        }
        else
        {
            VolumeDrawUp();
        }
    }

    public void VolumeDropDown()
    {
        _rightPanelAnimator.SetTrigger("VolumeDropDown");
        isVolumeDropped = true;
    }
    
    public void VolumeDrawUp()
    {
        _rightPanelAnimator.SetTrigger("VolumeDrawUp");
        isVolumeDropped = false;
    }
}
