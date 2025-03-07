using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseToggler : MonoBehaviour
{
    [SerializeField] private Sprite _paused;
    [SerializeField] private Sprite _playing;
    [SerializeField] private Image _image;

    private bool _isPaused = false;

    public void Toggle()
    {
        if (_isPaused)
        {
            _isPaused = false;
            _image.sprite = _playing;
        }
        else
        {
            _isPaused = true;
            _image.sprite = _paused;
        }
    }
}
