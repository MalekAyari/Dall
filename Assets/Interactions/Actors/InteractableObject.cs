using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Patisserie,
    Cirque,
    Boutique
}

public class InteractableObject : Interactable
{
    public ObjectType objectType;
    public string objectName;

    public override void Interact(Interaction interaction)
    {
        base.Interact(interaction);
        
        if (!FindObjectOfType<PlayerControls>().rhymes.Contains(objectName))
        {
            FindObjectOfType<PlayerControls>().rhymes.Add(objectName);
        }
    }

}
