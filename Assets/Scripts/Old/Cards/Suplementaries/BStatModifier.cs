using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BStatModifier : ScriptableObject
{
    [SerializeField] BStats _stat;
    [SerializeField] int _Value;

    public BStats stat => _stat;
    public int Value => _Value;
}
