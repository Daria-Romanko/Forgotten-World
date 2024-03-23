using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
    public Sprite litCandleSprite; // Спрайт для горящей свечи
    public Sprite candleSprite; // Спрайт для погашенной свечи

    private Button candleButton;
    private bool isLit = true;

    private void Start()
    {
        candleButton = GetComponent<Button>();
        candleButton.onClick.AddListener(ToggleCandle);
        ToggleCandle(); // Устанавливаем начальное состояние свечи
    }

    private void ToggleCandle()
    {
        isLit = !isLit; // Инвертируем состояние свечи

        if (isLit)
        {
            candleButton.image.sprite = litCandleSprite; // Изменяем спрайт на горящую свечу
        }
        else
        {
            candleButton.image.sprite = candleSprite; // Изменяем спрайт на погашенную свечу
        }
    }

    public bool IsLit()
    {
        return isLit;
    }
}
