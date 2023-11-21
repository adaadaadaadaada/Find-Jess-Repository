using UnityEngine;
using UnityEngine.Events;

public class Hiding : MonoBehaviour
{
    FirstPersonMovement _player;

    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<FirstPersonMovement>();
    }
    public void OnTriggerEnter(Collider other)
    {
        _player.isHiding = true;
        onTriggerEnter.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        _player.isHiding = false;
        onTriggerExit.Invoke();
    }
}