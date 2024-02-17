using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHint : MonoBehaviour
{
    public GameObject hint;

    [SerializeField]
    public GameObject _gameObject;

    [SerializeField]
    public string hintText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = hintText;
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
            _gameObject.SetActive(true);
        }
        else if (!collider.CompareTag("Player") && gameObject.activeInHierarchy)
        {
            _gameObject.SetActive(false);
        }

    }
}
