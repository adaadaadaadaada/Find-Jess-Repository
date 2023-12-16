using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class DialogEnd : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation1;
    FirstPersonMovement _player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(myConversation1);
                _player = GameObject.Find("Player").GetComponent<FirstPersonMovement>();
                _player.isHiding = true;
                _player.speed = 0;
                _player.canRun = false;

                StartCoroutine(WaitForSecond());
            }
        }
    }
    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(10);
        ConversationManager.Instance.EndConversation();
        SceneManager.LoadScene("Main Menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}