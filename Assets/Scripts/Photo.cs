using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public GameObject photo;

    public Image[] images;
    public Image finalImage;

    public GameObject finalPanel;
    public FinalSlideShow finalSlideShow;

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

        DialogueManager.StopAllConversations();

        count++;
        if (count == 1)
        {
            DialogueManager.ShowAlert("����� ������� ���������� ������� P");
            DialogueManager.Bark("PhotoFragment1", GameObject.FindGameObjectWithTag("Player").transform);
        }
        else
        {
            DialogueManager.ShowAlert("������� �������� ����������");
        }

        if (index == 3)
        {
            DialogueManager.Bark("PhotoFragment4", GameObject.FindGameObjectWithTag("Player").transform);
        }

        if (count == 5)
        {
            QuestLog.SetQuestState("����� ����������� ������", "success");

            foreach (var image in images)
            {
                image.gameObject.SetActive(false);
            }

            finalImage.gameObject.SetActive(true);

            StartCoroutine(PauseAndFinal());
        }
    }

    private IEnumerator PauseAndFinal()
    {
        yield return new WaitForSeconds(5f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().BlockPlayerMovement();

        photo.SetActive(true);

        DialogueManager.BarkString("������� � ���� ��� �� ����������...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return new WaitForSeconds(5f);

        pauseMenu.HidePuzzles();
        finalPanel.SetActive(true);
        finalSlideShow.PlaySlideShow();
    }

}
