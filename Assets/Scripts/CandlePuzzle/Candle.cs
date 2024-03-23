using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
    public Sprite litCandleSprite; // ������ ��� ������� �����
    public Sprite candleSprite; // ������ ��� ���������� �����

    private Button candleButton;
    private bool isLit = true;

    private void Start()
    {
        candleButton = GetComponent<Button>();
        candleButton.onClick.AddListener(ToggleCandle);
        ToggleCandle(); // ������������� ��������� ��������� �����
    }

    private void ToggleCandle()
    {
        isLit = !isLit; // ����������� ��������� �����

        if (isLit)
        {
            candleButton.image.sprite = litCandleSprite; // �������� ������ �� ������� �����
        }
        else
        {
            candleButton.image.sprite = candleSprite; // �������� ������ �� ���������� �����
        }
    }

    public bool IsLit()
    {
        return isLit;
    }
}
