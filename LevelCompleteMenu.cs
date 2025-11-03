using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    // This will load the next level
    public void NextLevel()
    {
        // Loads the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This will quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // Works in editor
        Application.Quit(); // Works in built game
    }
}
