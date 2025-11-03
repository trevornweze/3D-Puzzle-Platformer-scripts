using UnityEngine;
using TMPro;
using UnityEngine.UI;

// This script is a placeholder for player interaction functionality.
// It can be expanded to include various player interactions in the game.

public class GD_PlayerInteract : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3f;
    public GameObject interactionText;
    private GD_InteractObject currentInteractable;


    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            GD_InteractObject interactableObject = hit.collider.GetComponent<GD_InteractObject>();
            if (interactableObject != null && interactableObject != currentInteractable) ;
            {
                currentInteractable = interactableObject;
                interactionText.SetActive(true);
                TextMeshProUGUI textComponent = interactionText.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = currentInteractable.GetInteractionText();
                }
                
            }
        }
        else
        {
            currentInteractable = null;
            interactionText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable?.Interact();
        }
    }
}
