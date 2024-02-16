using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    private GameObject[] puzzle;
    public static bool isCorrect;

    private void Start()
    {
        puzzle = GameObject.FindGameObjectsWithTag("PuzzleRotate");
        isCorrect = false;
    }

    private void Update()
    {
        if (PuzzleRotate.isMouse)
        {
            bool allTrue = true;
            foreach (GameObject item in puzzle)
            {
                if (item.transform.rotation.z < -0.01 || item.transform.rotation.z > 0.01)
                {
                    allTrue = false;
                    break;
                }
            }
            if (allTrue)
            {
                isCorrect = true;
                Debug.Log("YOU WIN");
            }
        }
        PuzzleRotate.isMouse = false;
    }
}