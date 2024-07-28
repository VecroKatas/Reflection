using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusStatNode : MonoBehaviour
{
    public SStats Sstat;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Slider healthbar;
    [SerializeField] private TextMeshProUGUI _score;

    private StatusStat _stat;
    
    private void Start()
    {
        _stat = Stats.GetStatusStatByAbbreviation(Sstat);
    }

    private void FixedUpdate()
    {
        _name.text = _stat.Name;
        _score.text = Math.Round(_stat.Score, 1) + "%";
        healthbar.value = _stat.Score / 100;
    }
}
