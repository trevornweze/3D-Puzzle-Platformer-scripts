using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    private int objectsOnPlate = 0;

    void Start()
    {
        if (door != null)
            door.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Moveable"))
        {
            objectsOnPlate++;
            if (door != null)
                door.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Moveable"))
        {
            objectsOnPlate--;
            if (objectsOnPlate <= 0 && door != null)
                door.SetActive(false);
        }
    }
}
