
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;

    public TMP_Text objectNameText;
    public TMP_Text descriptionText;

    private Interactable nearbyObject;
    private bool dialogueOpen = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (nearbyObject != null && !dialogueOpen)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                OpenDialogue();
            }
        }
        else if (dialogueOpen)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CloseDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable =
            other.GetComponent<Interactable>();

        if (interactable != null && !dialogueOpen)
        {
            nearbyObject = interactable;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactable =
            other.GetComponent<Interactable>();

        if (interactable != null &&
            interactable == nearbyObject)
        {
            nearbyObject = null;

            if (dialogueOpen)
            {
                CloseDialogue();
            }
        }
    }

    void OpenDialogue()
    {
        dialogueOpen = true;
        dialoguePanel.SetActive(true);

        objectNameText.text = nearbyObject.objectName;
        descriptionText.text = nearbyObject.description;
    }

    void CloseDialogue()
    {
        dialogueOpen = false;
        dialoguePanel.SetActive(false);
    }
}
