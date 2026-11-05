using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectName = "Rock";

    [TextArea]
    public string description = "This is a Rock.";

    public void Interact()
    {
        Debug.Log(objectName + ": " + description);
    }
}
