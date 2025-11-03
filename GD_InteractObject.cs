using UnityEngine;
using UnityEngine.Events;

public class GD_InteractObject : MonoBehaviour
{
    public string interactionText = "Press E to interact";
    public UnityEvent onInteract;
    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    { 
        onInteract.Invoke();
    }


}

