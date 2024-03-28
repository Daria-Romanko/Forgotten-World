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
                photo.SetActivePhotoFragment(1);
                DialogueLua.SetVariable("SafePuzzle", true);
                DialogueManager.Bark("SafeBark", GameObject.FindGameObjectWithTag("Player").transform);
                this.gameObject.GetComponent<AddItemInInventory>().AddItem();

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
