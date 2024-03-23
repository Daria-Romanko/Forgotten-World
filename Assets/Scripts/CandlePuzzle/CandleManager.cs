using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    public List<Candle> candles; // ������ ������
    private List<bool> correctCandles = new List<bool> { false, false, true, true,false,false,false,true,false }; // ���������� ������� ��������� ������

    private void Update()
    {

        if (CheckSolution()) // ��������� ������� ����� ������� �������� � �������
        {
            Debug.Log("�����������, ����������� ������!");
            // ����� ����� �������� �������������� �������� ��� �������� �������
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
