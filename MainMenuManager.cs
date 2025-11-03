using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    [SerializeField] private string _sceneToLoadAfterClickingPlay;

    public enum MainMenuBottons { StartGame, Levels, HowToPlay, Settings, Quit };

    public void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
        else
        {
            Debug.LogError("there is already a MainMenuManager in the scene, destroying this one.");
            
        }
    }
    public void MainMenuButtonClicked(MainMenuBottons buttonClicked)
    {
        DebugMessage("Button clicked:" + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuBottons.StartGame:
                StartGameClicked();
                DebugMessage("Starting game...");
               
                break;
            case MainMenuBottons.Levels:
                DebugMessage("Opening levels menu...");
                
                break;
            case MainMenuBottons.HowToPlay:
                DebugMessage("Opening how to play menu...");
              
                break;
            case MainMenuBottons.Settings:
                DebugMessage("Opening settings menu...");
              
                break;
            case MainMenuBottons.Quit:
                DebugMessage("Quitting game...");
                QuitGame();
                break;
        }
    }
    private void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }

    }
    public void StartGameClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        DebugMessage("Game is quitting...");
    }
}
