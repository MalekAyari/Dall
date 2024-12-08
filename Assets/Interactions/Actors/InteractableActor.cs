using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableActor : Interactable
{

    public string requestedItem;

    public Interaction linesWhenReady;

    public override void Interact(Interaction interaction)
    {

        //Check if player has clue
        if (!FindObjectOfType<PlayerControls>().rhymes.Contains(requestedItem))
        {
            base.Interact(interaction);
        } else
        {
            base.Interact(linesWhenReady);
        }

        //during dialogue check if correct then play success message

        //else play smallest violin
    }
}
