using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public Photo photo;

    [SerializeField]
    TMP_Text codeText;

    string codeTextValue = "";

    bool isSafeOpened = false;

    [SerializeField]
    GameObject safe;

    private void Update()
    {
        if (!isSafeOpened)
        {           
            codeText.text = codeTextValue;

            if (codeTextValue == "0451")
            {
                isSafeOpened = true;
                safe.GetComponent<ShowHint>().SetPuzzleSolved();
                photo.SetActivePhotoFragment(2);
                DialogueManager.Bark("PhotoFragment3", GameObject.FindGameObjectWithTag("Player").transform);
                DialogueLua.SetVariable("SafePuzzle", true);

            }

            if (codeTextValue.Length >= 4)
            {
                codeTextValue = "";
            }
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
