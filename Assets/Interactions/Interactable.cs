using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private DialogueManager dialogueManager;

    public Interaction interaction;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager not found in the scene!");
        }
    }

    void Update()
    {
        if (dialogueManager == null)
        {
            Debug.Log("Dialogue manager is null");
            return;
        }

        // If dialogue is not playing and the player is in range, start dialogue
        if (!dialogueManager.playing && isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact(interaction);
            Debug.Log("Started dialogue from " + gameObject.name);
        }
        // If dialogue is playing, continue to the next line
        else if (dialogueManager.playing && isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextLine();
            Debug.Log("Continued dialogue from" + gameObject.name);
        }
    }
    
    public virtual void Interact(Interaction interaction)
    {   
        Debug.Log("Interacting with: " + gameObject.name);
        dialogueManager.StartDialogue(interaction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Player entered range of {gameObject.name}");
        isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Player exited range of {gameObject.name}");
        isPlayerInRange = false;
    }
}
