using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    public AudioSource phoneRingSound;
    public AnswerPhone answerPhone;

    public void Start()
    {
        answerPhone = gameObject.GetComponentInParent<AnswerPhone>();
    }

    public void StartRinging()
    {
        phoneRingSound.Play();
    }

    public void StopRinging()
    {
        phoneRingSound.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !answerPhone.flag)
        {
            StartRinging();
        }
    }


}
