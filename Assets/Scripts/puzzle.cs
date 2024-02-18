using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;

    public NumberBox[,] boxes = new NumberBox[4, 4];

    public Sprite[] sprites;
    void Start()
    {
        Init();
    }

    public void Init()
    {
        int n = 0;
        for(int y=3;y>=0;y--)
            for(int x=0;x<4;x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n]);
                n++;
                boxes[x, y] = box;
            }
    }
}
