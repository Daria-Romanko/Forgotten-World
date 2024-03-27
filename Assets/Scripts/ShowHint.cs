using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class ShowHint : MonoBehaviour
{
    public GameObject hint;

    [SerializeField]
    public GameObject _gameObject;

    [SerializeField]
    public GameObject player;

    private PlayerController playerController;

    private bool puzzleSolved;

    public bool inspected;
    public bool changeSprite;

    public Sprite newSprite = null;
    bool playerInColliderFlag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!puzzleSolved || inspected)
            {
                hint.SetActive(true);
                hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
                playerInColliderFlag = true;
            }           
            else
            {
                hint.SetActive(false);
                playerInColliderFlag = false;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
            playerInColliderFlag = false;
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        puzzleSolved = false;
    }

    private void Update()
    {
        if (playerInColliderFlag && Input.GetKeyDown(KeyCode.E))
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
        
        if (changeSprite)
        {
            ChangeSprite();
        }
       
        if (inspected)
        {
            hint.SetActive(true);
        }
        else
        {
            hint.SetActive(false);
            _gameObject.SetActive(false);
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
