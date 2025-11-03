using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private int step = 0;

    private string[] messages = {
        "Use WASD or arrow keys to move",
        "Press Left Shift + WASD/direction to run",
        "Press Spacebar to jump",
        "Press E to push and Q to pull objects around",
        "Press C to crawl",
        "Move the object onto the pressure plate to exit the level"
    };

    void Start()
    {
        tutorialText.text = messages[0];
    }

    void Update()
    {
        switch (step)
        {
            case 0:
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                    NextStep();
                break;
            case 1:
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) &&
                    (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
                    NextStep();
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space))
                    NextStep();
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
                    NextStep();
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.C))
                    NextStep();
                break;
        }
    }

    void NextStep()
    {
        step++;
        if (step < messages.Length)
            tutorialText.text = messages[step];
        else
            tutorialText.gameObject.SetActive(false);
    }
}
