using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEditor;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DialogStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    FirstPersonMovement _player;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                ConversationManager.Instance.StartConversation(myConversation);
                _player = GameObject.Find("Player").GetComponent<FirstPersonMovement>();
                _player.speed = 0;
                _player.canRun = false;

                StartCoroutine(WaitForSecond());

            }
        }
    }
    //private void OnTriggerExit(Collider other)
   // {
   //     ConversationManager.Instance.EndConversation();
   // }
    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(7);
        ConversationManager.Instance.EndConversation();
        _player.speed = 5;
        _player.canRun = true;
    }
}