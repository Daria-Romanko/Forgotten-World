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
    public string text;

    private PlayerController playerController;

    private bool puzzleSolved = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !puzzleSolved)
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || puzzleSolved )
        {
            hint.SetActive(false);
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);

        if (collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!puzzleSolved)
            {
                _gameObject.SetActive(true);
                playerController.BlockPlayerMovement();
                hint.SetActive(false);
            }
        }
        if(collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            _gameObject.SetActive(false);
            playerController.UnblockPlayerMovement();
        }       
    }

    public void SetPuzzleSolved()
    {
        puzzleSolved = true;
        hint.SetActive(false);
        _gameObject.SetActive(false);
        playerController.UnblockPlayerMovement();
    }
}
