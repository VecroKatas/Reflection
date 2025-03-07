using UnityEngine;

public class MusicPlayerUI : MonoBehaviour
{
    // temporary ?
    [SerializeField] private Animator _leftPanelAnimator;
    [SerializeField] private Animator _rightPanelAnimator;

    public void LeftDropDown()
    {
        _leftPanelAnimator.SetTrigger("DropDown");
    }
    
    public void LeftDrawUp()
    {
        _leftPanelAnimator.SetTrigger("DrawUp");
    }
    
    public void RightSlideIn()
    {
        _rightPanelAnimator.SetTrigger("SlideIn");
    }
    
    public void RightSlideOut()
    {
        _rightPanelAnimator.SetTrigger("SlideOut");
    }

    public void VolumeDropDown()
    {
        _rightPanelAnimator.SetTrigger("VolumeDropDown");
    }
    
    public void VolumeDrawUp()
    {
        _rightPanelAnimator.SetTrigger("VolumeDrawUp");
    }
}
