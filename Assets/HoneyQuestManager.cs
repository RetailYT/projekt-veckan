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
        dialoguePanel.SetActive(false);
        questText.gameObject.SetActive(true);
        UpdateQuest();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            if (dialoguePanel.activeSelf)
                CloseDialogue();
            else
                Talk();
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
        if (!started)
        {
            started = true;
            ShowDialogue("Hello explorer! Can you please help me find my 5 honey bottles?");
        }
        else if (collectedBottles < requiredBottles)
        {
            ShowDialogue("I still need " +
                (requiredBottles - collectedBottles) +
                " more honey bottles!");
        }
        else
        {
            completed = true;
            ShowDialogue("Thank you! You found all my honey bottles! Thank you for playing!");
        }

        UpdateQuest();
    }

    public void CollectBottle()
    {
        if (!started || completed || collectedBottles >= requiredBottles)
            return;

        collectedBottles++;
        UpdateQuest();
    }

    void UpdateQuest()
    {
        questText.text = !started ? "Find the quest giver!" :
            completed ? "Quest completed!" :
            collectedBottles >= requiredBottles ? "Talk to the quest giver!" :
            "Find " + (requiredBottles - collectedBottles) + " honey bottles";
    }

    void ShowDialogue(string message)
    {
        dialoguePanel.SetActive(true);

        if (typing != null)
            StopCoroutine(typing);

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

        dialogueText.text += "\n[Z to continue]";
        typing = null;
    }

    void CloseDialogue()
    {
        if (typing != null)
        {
            StopCoroutine(typing);
            typing = null;
        }

        dialoguePanel.SetActive(false);
    }
}
