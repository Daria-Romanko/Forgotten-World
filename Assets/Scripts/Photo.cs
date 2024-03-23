using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    public GameObject photo;

    public Image[] images;

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
        photo.SetActive(true);
        images[index].gameObject.SetActive(true);
    }
}
