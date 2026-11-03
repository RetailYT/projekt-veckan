using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
 
    public void StartGame()
    {
        SceneManager.LoadScene("testMap");
    }
    public void QuitGame()
    {
        Application.Quit();
    }   

    public void PlatformGame()
    {
        SceneManager.LoadScene("platformerTestMap");
    }
}
