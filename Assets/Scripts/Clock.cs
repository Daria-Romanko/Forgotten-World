using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Transform minuteHand, hourHand;

    private void Start()
    {
       
    }

    private void OnMouseDown()
    {
        minuteHand.Rotate(Vector3.back, 30);
        hourHand.Rotate(Vector3.back, 2.5f);

        if((Mathf.Round(minuteHand.rotation.eulerAngles.z * 2) / 2) == 30 && (Mathf.Round(hourHand.rotation.eulerAngles.z * 2) / 2) == 212.5f)
        {
            Debug.Log("Win");
        }
    }
}
