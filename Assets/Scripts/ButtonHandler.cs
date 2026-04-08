using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
