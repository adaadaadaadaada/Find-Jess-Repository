using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("toimii!");
    }
}
