using UnityEngine;

public class HoneyBottle : MonoBehaviour
{
    bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            HoneyQuestManager quest = HoneyQuestManager.Instance;

            if (quest == null)
                return;

            if (!quest.started || quest.completed)
                return;

            if (quest.collectedBottles >= quest.requiredBottles)
                return;

            quest.CollectBottle();

            Destroy(gameObject);
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
