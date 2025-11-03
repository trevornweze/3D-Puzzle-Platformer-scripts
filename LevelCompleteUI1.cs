using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI1 : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void Show()
    {
        levelCompleteUI.SetActive(true);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
