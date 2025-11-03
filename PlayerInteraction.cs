using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 2f;
    public float pushForce = 10f;
    public Transform playerCamera; // drag in your camera

    private GameObject targetObject;

    void Update()
    {
        CheckForMovableObject();

        if (targetObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Push
            {
                PushOrPullObject(true);
            }
            else if (Input.GetKeyDown(KeyCode.Q)) // Pull
            {
                PushOrPullObject(false);
            }
        }
    }

    void CheckForMovableObject()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Movable"))
            {
                targetObject = hit.collider.gameObject;
                return;
            }
        }

        targetObject = null;
    }

    void PushOrPullObject(bool isPush)
    {
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = isPush ? transform.forward : -transform.forward;
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }
}
