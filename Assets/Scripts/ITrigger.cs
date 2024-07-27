using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    public int ID { get; }
    public bool IsTriggered { get; set; }
}

class Trigger : ScriptableObject, ITrigger
{
    public int ID { get; }
    public bool IsTriggered { get; set; }
}
