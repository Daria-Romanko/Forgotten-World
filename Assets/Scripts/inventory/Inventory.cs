using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Data;

public class Inventory : MonoBehaviour
{
    public DataBase data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;

    public int MaxCount;

    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }

        for(int i=0;i<MaxCount;i++)//тест заполнить рандомные €чейки
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99));
        }
        UpdateInventory();
    }

    public void Update()
    {
        if (currentID != -1)
        {
            MoveOvject();
        }
    }


    public void AddItem(int id,Item item,int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].ItemGameObj.GetComponent<Image>().sprite = item.img;

        if(count>1&&item.id!=0)
        {
            items[id].ItemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].ItemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }


    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].ItemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;

        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].ItemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].ItemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for(int i=0;i<MaxCount;i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.ItemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < MaxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].ItemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].ItemGameObj.GetComponentInChildren<Text>().text = "";
            }

            items[i].ItemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject()
    {
        if(currentID==-1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyIventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0);
        }
        else
        {
            AddInventoryItem(currentID, items[int.Parse(es.currentSelectedGameObject.name)]);

            AddInventoryItem(int.Parse(es.currentSelectedGameObject.name),currentItem);
            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }


    public void MoveOvject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyIventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.ItemGameObj = old.ItemGameObj;
        New.count = old.count;

        return New;
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject ItemGameObj;
    
    public int count;
}