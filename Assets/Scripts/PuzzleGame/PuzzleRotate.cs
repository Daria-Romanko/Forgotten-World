using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotate : MonoBehaviour
{
    public static bool isMouse;
    private void Start()
    {
        int[] rotate = { 0, 90, 180, 270 };
        transform.Rotate(0, 0, rotate[Random.Range(0, rotate.Length)]);
        isMouse = false;
    }

    private void OnMouseDown()
    {
        if (!RotateManager.isCorrect)
        {
            isMouse = true;
            transform.Rotate(0, 0, 90);
        }
    }
}
