using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text objectNameText;
    public TMP_Text descriptionText;

    private Interactable nearbyObject;
    private bool dialogueOpen;

    private Rigidbody2D rb;
    private RigidbodyConstraints2D originalConstraints;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (nearbyObject != null && Input.GetKeyDown(KeyCode.Z))
        {
            if (dialogueOpen)
                CloseDialogue();
            else
                OpenDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();

        if (interactable != null)
            nearbyObject = interactable;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();

        if (interactable != null && interactable == nearbyObject)
        {
            nearbyObject = null;

            if (dialogueOpen)
                CloseDialogue();
        }
    }

    void OpenDialogue()
    {
        dialogueOpen = true;
        dialoguePanel.SetActive(true);

        objectNameText.text = nearbyObject.objectName;
        descriptionText.text = nearbyObject.description;

        originalConstraints = rb.constraints;
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void CloseDialogue()
    {
        dialogueOpen = false;
        dialoguePanel.SetActive(false);

        rb.constraints = originalConstraints;
    }
}
