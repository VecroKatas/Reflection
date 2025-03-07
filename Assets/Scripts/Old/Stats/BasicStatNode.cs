using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicStatNode : MonoBehaviour
{
    public BStats bstat;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;

    private BasicStat _stat;
    
    private void Start()
    {
        _stat = Stats.GetBasicStatByAbbreviation(bstat);
    }

    private void FixedUpdate()
    {
        _name.text = _stat.Name;
        _score.text = _stat.Score.ToString();
    }
}
