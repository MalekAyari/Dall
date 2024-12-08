using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool playing = false;
    public Queue<string> lines;

    public TextMeshProUGUI speaker;
    public TextMeshProUGUI lineText;

    public Animator boxAnimator;
    public Animator portraitAnimator;
    public Animator cursorAnimator;

    private void Start()
    {
        lines = new Queue<string>();
    }

    public void StartDialogue(Interaction interaction)
    {
        boxAnimator.SetBool("isOpen", true);
        portraitAnimator.SetBool("isOpen", true);
        cursorAnimator.SetBool("Ready", false);

        speaker.text = interaction.speaker;

        lines.Clear();
        foreach (string line in interaction.lines)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        playing = true;

        string line = lines.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));

        Debug.Log(line);
    }

    public void EndDialogue()
    {
        playing = false;
        boxAnimator.SetBool("isOpen", false);
        portraitAnimator.SetBool("isOpen", false);
    }

    IEnumerator TypeLine(string line)
    {
        bool opened = false;
        lineText.text = "";
        char[] letters = line.ToCharArray();

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] == '<' && !opened)  // Start color tag
            {
                lineText.text += "<color=red>";
                opened = true;
                // Skip ahead to the closing '>'
                while (i < letters.Length && letters[i] != '>')
                    i++;
            }
            else if (letters[i] == '<' && opened)  // End color tag
            {
                lineText.text += "</color>";
                opened = false;
                while (i < letters.Length && letters[i] != '>')
                    i++;
            }
            else
            {
                lineText.text += letters[i];
            }

            yield return new WaitForSeconds(0.025f);
        }

        cursorAnimator.SetBool("Ready", true);
    }



}
