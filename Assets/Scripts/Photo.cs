using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public GameObject photo;

    public Image[] images;

    public int count = 0;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            photo.SetActive(!photo.activeSelf);
        }
    }

    public void SetActivePhotoFragment(int index)
    {
        images[index].gameObject.SetActive(true);

        DialogueManager.StopConversation();

        count++;
        if (count == 1)
        {
            DialogueManager.ShowAlert("Чтобы открыть фотографию нажмите P");
            DialogueManager.StartConversation("PhotoFragment1", GameObject.FindGameObjectWithTag("Player").transform);
        }
        else
        {
            gameObject.SetActive(true);
        }

        if (index == 3)
        {
            DialogueManager.StartConversation("PhotoFragment4", GameObject.FindGameObjectWithTag("Player").transform);
        }
    }
}
