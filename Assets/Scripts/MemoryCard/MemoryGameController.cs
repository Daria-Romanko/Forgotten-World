using Inventory2.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
    public GameObject gamePanel;

    [SerializeField]
    private Sprite backgroundImage;

    public Sprite[] cards;

    public List<Sprite> gameCards = new List<Sprite>();

    public List<Button> buttons = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessCard, secondGuessCard;

    public InventoryItem rewardItem;

    public InventorySO inventory;

    public void ShowGamePanel()
    {
        gamePanel.gameObject.SetActive(true);

        GetButtons();
        AddListeners();
        AddGameCards();
        Shuffle(gameCards);

        gameGuesses = gameCards.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardButton");
        for(int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = backgroundImage;
        }
    }

    void AddListeners()
    {
        foreach(Button button in buttons)
        {
            button.onClick.AddListener(() => PickUpPuzzle());
        }
    }

    void AddGameCards()
    {
        int looper = buttons.Count;
        int index = 0;

        for(int i = 0;i < looper;i++) 
        { 
            if(index == looper / 2)
            {
                index = 0;
            }
            gameCards.Add(cards[index]);

            index++;
        }

    }
    public void PickUpPuzzle()
    {
        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessCard = gameCards[firstGuessIndex].name;

            buttons[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessCard = gameCards[secondGuessIndex].name;

            buttons[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];

            StartCoroutine(CheckIfTheCardsMatch());
        }
    }

    IEnumerator CheckIfTheCardsMatch()
    {
        yield return new WaitForSeconds(1f);

        if(firstGuessCard == secondGuessCard && firstGuessIndex != secondGuessIndex)
        {
            yield return new WaitForSeconds(0.5f);

            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;

            buttons[firstGuessIndex].image.color = new Color(0,0,0,0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckInTheGameIsFiniched();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            buttons[firstGuessIndex].image.sprite = backgroundImage; 
            buttons[secondGuessIndex].image.sprite = backgroundImage;
        }

        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;
    }

    private void CheckInTheGameIsFiniched()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses) 
        {
            inventory.AddItem(rewardItem);

            gamePanel.SetActive(false);
        }  

    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count - 1);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
