using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEditor;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DialogEnd : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                _player = GameObject.Find("Player").GetComponent<FirstPersonMovement>();
                _player.speed = 0;
                _player.canRun = false;
                ConversationManager.Instance.StartConversation(myConversation);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ConversationManager.Instance.EndConversation();
    }
}