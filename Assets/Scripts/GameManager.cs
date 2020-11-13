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
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("Bullets", 15);
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Game01");
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public void DamagePlayer()
    {
        int lives = PlayerPrefs.GetInt("Lives") - 1;
        PlayerPrefs.SetInt("Lives", lives);

        if (lives <= 0) 
        {
            Died();
        }
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
