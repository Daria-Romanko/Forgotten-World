using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShowBulletinBoardInfo : MonoBehaviour
{
    public GameObject bulletinBoardPanel;

    public GameObject hint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
        }
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);

        if (collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            bulletinBoardPanel.SetActive(true);
        }
        else if(!collider.CompareTag("Player") && bulletinBoardPanel.activeInHierarchy)
        {
            bulletinBoardPanel.SetActive(false);
        }
        
    }
}
