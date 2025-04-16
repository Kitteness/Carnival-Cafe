using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exiting...");
    }
}
