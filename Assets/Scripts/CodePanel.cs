using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    TMP_Text codeText;

    string codeTextValue = "";

    bool isSafeOpened = false;

    private void Update()
    {
        if (!isSafeOpened)
        {
            if (codeTextValue.Length >= 4)
            {
                codeTextValue = "";
            }

            codeText.text = codeTextValue;

            if (codeTextValue == "0451")
            {
                isSafeOpened = true;
            }
        }
        else
        {
            this.gameObject.SetActive(false);
            //
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!isSafeOpened && Input.GetKeyDown(KeyCode.E))
    //    {
    //        this.gameObject.SetActive(true);
    //    }
    //}

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
