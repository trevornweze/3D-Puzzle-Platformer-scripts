using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }
}
