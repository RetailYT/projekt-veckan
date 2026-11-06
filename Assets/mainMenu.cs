using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
 
    public void StartGame() // Start the game and load the overworld scene
    {
        SceneManager.LoadScene("Overworld"); // Load the overworld scene
    }
    public void QuitGame() // Quit the game
    {
        Application.Quit();
    }   

    public void PlatformGame() // Load the platformer test map (for testing purposes (now removed and unusable))
    {
        SceneManager.LoadScene("platformerTestMap");
    }

    public void Credits() // Load the credits scene
    {
        SceneManager.LoadScene("Credits");
    }
}
