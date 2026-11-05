
using UnityEngine;

public class HoneyQuestNPC : MonoBehaviour
{
    public HoneyQuestManager quest;
    private bool playerNearby;

    void Start()
    {
        if (quest == null)
            quest = GetComponent<HoneyQuestManager>();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            if (!quest.dialoguePanel.activeSelf)
                quest.Talk();
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
            playerNearby = false;
    }
}
