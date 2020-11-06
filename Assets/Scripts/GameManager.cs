using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LaunchMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextStage()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "Menu")
        {
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Game01");
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public void RestartLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("EndGame");
    }

    public void Died()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Died");
    }
}
