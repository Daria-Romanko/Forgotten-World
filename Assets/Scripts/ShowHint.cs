using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHint : MonoBehaviour
{
    public GameObject hint;

    [SerializeField]
    public GameObject _gameObject;

    private PlayerController playerController;

    private bool puzzleSolved;

    public bool inspected;
    public bool changeSprite;

    public Sprite newSprite = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !puzzleSolved && inspected)
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || puzzleSolved && !inspected)
        {
            hint.SetActive(false);
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        puzzleSolved = false;
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);

        if (collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (!puzzleSolved | inspected)
            {
                _gameObject.SetActive(true);
                playerController.BlockPlayerMovement();
                hint.SetActive(false);
            }      
        }
        if(Input.GetKeyDown(KeyCode.Q) && _gameObject.activeSelf)
        {
            _gameObject.SetActive(false);
            hint.SetActive(true);
            playerController.UnblockPlayerMovement();
        }       
    }

    public void SetPuzzleSolved()
    {
        puzzleSolved = true;
        hint.SetActive(false);
        _gameObject.SetActive(false);

        if (changeSprite)
        {
            ChangeSprite();
        }

        playerController.UnblockPlayerMovement();
    }

    public bool GetPuzzleSolved()
    {
        return  puzzleSolved;
    }

    private void ChangeSprite()
    {
        if(newSprite != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
