using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public string speaker;

    [TextArea(3, 5)]
    public List<string> lines = new List<string>();
}
