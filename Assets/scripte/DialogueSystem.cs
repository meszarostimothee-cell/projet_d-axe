using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    [TextArea(3, 5)]
    public string[] dialogueLines;

    private int currentLine = 0;

    private bool playerNearby = false;
    private bool isDialogueActive = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                StartDialogue();
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;

        dialoguePanel.SetActive(true);

        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;

        dialoguePanel.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;

            EndDialogue();
        }
    }
}