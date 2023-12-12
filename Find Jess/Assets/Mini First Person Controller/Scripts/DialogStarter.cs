using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEditor;
using Unity.VisualScripting;

public class DialogStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ConversationManager.Instance.EndConversation();
    }
}
