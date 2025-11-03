using UnityEngine;

public class DrawAttention : MonoBehaviour
{
    [SerializeField] int rotateSpeed = 2;
    // [SerializeField] AudioSource bleepSound;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // bleepSound.Play();
        // Destroy(gameObject);
    }
}
