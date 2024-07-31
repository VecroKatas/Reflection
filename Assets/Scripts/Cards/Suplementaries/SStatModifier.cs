using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SStatModifier : ScriptableObject
{
    [SerializeField] SStats _stat;
    [SerializeField] float _Value;

    public SStats stat => _stat;
    public float Value => _Value;
}
