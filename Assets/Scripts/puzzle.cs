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
                NumberBox box = Instantiate(boxPrefab, transform.position, Quaternion.identity, gameObject.transform);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                n++;
                boxes[x, y] = box;
            }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        var from = boxes[x, y];
        var target = boxes[x+dx, y+dy];

        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        if(x < 3 && boxes[x + 1, y].IsEmpty())
        {
            return 1;
        }

        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
        }

        return 0;
    }

    int getDy(int x, int y)
    {
        if (y < 3 && boxes[x, y + 1].IsEmpty())
        {
            return 1;
        }

        if (y > 0 && boxes[x, y - 1].IsEmpty())
        {
            return -1;
        }

        return 0;
    }
}
