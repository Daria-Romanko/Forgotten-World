using InventoryUI;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI: MonoBehaviour
{   

    public void StartGame()
    {
        if (DialogueManager.Instance.transform.GetChild(0).GetChild(1).GetChild(0).gameObject != null && DialogueManager.Instance.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.name != "Quest Track Template")
        {
            DialogueManager.Instance.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        }

        DialogueManager.Instance.ResetDatabase();

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
