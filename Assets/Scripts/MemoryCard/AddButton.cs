using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject bth;

    private void Awake()
    {
        for(int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(bth);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
        
    }
}
