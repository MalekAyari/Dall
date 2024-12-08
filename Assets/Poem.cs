using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Request
{
    Baguette,
    Croissant,
    Biscuit,

}

[CreateAssetMenu(menuName = "Poem")]
public class Poem : ScriptableObject
{
    public Interaction interaction;

    public string request;

    
}
