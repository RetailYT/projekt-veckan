using UnityEngine;

public class backToMenu : MonoBehaviour
{


    public void BackToMenu() // Load the main menu scene
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }


}
