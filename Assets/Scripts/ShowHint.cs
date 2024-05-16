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

    public GameObject pauseMenu;

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
        if (Input.GetKeyDown(KeyCode.E) && playerInColliderFlag)
        {
            if (_gameObject.activeSelf == false)
            {
                if(!puzzleSolved | inspected)
                {
                    _gameObject.SetActive(true);
                    playerController.BlockPlayerMovement();
                    hint.SetActive(false);
                }        
            }
            else
            {
                _gameObject.SetActive(false);
                if (inspected)
                {
                    hint.SetActive(true);
                }
                else 
                { 
                    hint.SetActive(false); 
                }
                playerController.UnblockPlayerMovement();
            }
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
