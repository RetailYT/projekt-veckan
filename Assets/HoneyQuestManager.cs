using UnityEngine;
using TMPro;
using System.Collections;

public class HoneyQuestManager : MonoBehaviour
{
    public static HoneyQuestManager Instance;

    public int requiredBottles = 5;
    public int collectedBottles;
    public bool started, completed;

    public TMP_Text questText, dialogueText;
    public GameObject dialoguePanel;

    bool playerNearby;
    Coroutine typing;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        questText.gameObject.SetActive(started);
        dialoguePanel.SetActive(false);
        UpdateQuest();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            if (dialoguePanel.activeSelf) CloseDialogue();
            else Talk();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            CloseDialogue();
        }
    }

    public void Talk()
    {
        started = true;
        questText.gameObject.SetActive(true);

        if (collectedBottles >= requiredBottles)
        {
            completed = true;
            ShowDialogue("Thank you! You found all my honey bottles!... And Thank you for playing the demo game!");
        }
        else if (collectedBottles == 0)
            ShowDialogue("Hello explorer! Can you please help me find my 5 honey bottles!");
        else
            ShowDialogue("I still need " + (requiredBottles - collectedBottles) + " honey bottles!");

        UpdateQuest();
    }

    public void CollectBottle()
    {
        if (!started || completed || collectedBottles >= requiredBottles) return;

        collectedBottles++;
        UpdateQuest();
    }

    void UpdateQuest()
    {
        questText.text = completed ? "Demo-Quest completed!" : collectedBottles >= requiredBottles ? "Talk to the quest giver!" : "Find " + (requiredBottles - collectedBottles) + " honey bottles";
    }

    void ShowDialogue(string message)
    {
        dialoguePanel.SetActive(true);
        if (typing != null) StopCoroutine(typing);
        typing = StartCoroutine(TypeText(message));
    }

    IEnumerator TypeText(string message)
    {
        dialogueText.text = "";
        foreach (char c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.035f);
        }
        typing = null;
    }

    void CloseDialogue()
    {
        if (typing != null) StopCoroutine(typing);
        typing = null;
        dialoguePanel.SetActive(false);
    }
}