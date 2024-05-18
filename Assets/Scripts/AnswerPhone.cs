using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPhone : MonoBehaviour
{
    private PhoneTrigger trigger;

    public bool flag = false;
    private bool inCollider = false;

    void Start()
    {
        trigger = GetComponentInChildren<PhoneTrigger>();
    }

    void Update()
    {
        if (inCollider && Input.GetKeyDown(KeyCode.E))
        {
            flag = true;
            trigger.StopRinging();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = false;
        }
    }

}
