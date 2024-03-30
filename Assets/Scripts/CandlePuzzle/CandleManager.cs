using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    public Photo photo;
    public List<Candle> candles; // ������ ������
    private List<bool> correctCandles = new List<bool> { true, true, true, false, false,false,false,true}; // ���������� ������� ��������� ������
    public GameObject candle;
    private void Update()
    {
        if (CheckSolution()) // ��������� ������� ����� ������� �������� � �������
        {
            DialogueManager.Bark("CandleBark", GameObject.FindGameObjectWithTag("Player").transform);
            photo.SetActivePhotoFragment(4);
            DialogueManager.StartConversation("PhotoFragment5", GameObject.FindGameObjectWithTag("Player").transform);
            candle.GetComponent<ShowHint>().SetPuzzleSolved();
        }

    }

    private bool CheckSolution()
    {
        List<bool> litCandles= new List<bool>();
        for (int i = 0; i < candles.Count; i++)
        {
            litCandles.Add(candles[i].IsLit());
        }

        return litCandles.SequenceEqual(correctCandles);
    }

}
