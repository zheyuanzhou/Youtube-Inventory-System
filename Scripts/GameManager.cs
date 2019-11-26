using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    //STEP 02
    public Item[] itemReferences;//MARKER REFERENCES by advantage
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public Item exampleAddItem;//TODO Connected with pickup Later
    public Item exampleAddItem2;
    public Item exampleRemoveItem;//TODO Connect with the Throw button Later

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DisplayItems();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            AddItem(exampleAddItem);
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            AddItem(exampleAddItem2);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RemoveItem(exampleRemoveItem);
        }

    }

    //STEP 02 
    private void DisplayItems()
    {
        #region 
        //MARKER Before CODING [RemoveItem] function
        //for(int i = 0; i < items.Count; i++)
        //{
        //    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

        //    slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
        //    slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
        //    slots[i].transform.GetChild(2).gameObject.SetActive(true);
        //}
        #endregion

        for (int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }

    }

    public void AddItem(Item _item)//STEP 03 TODO IF my Bag is FULL
    {
        if(!items.Contains(_item))//MARKER There is existing item inside your Bag
        {
            //ADD ITEMS
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            //ADD ITEM NUMBER
            Debug.Log("You have already have this one!");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }

        DisplayItems();
    }

    //MARKER When we press the close Button
    public void RemoveItem(Item _item)
    {
        //MARKER IF there is existing item inside Bag
        if (items.Contains(_item))
        {
            //items.Remove(_item);
            for(int i = 0; i < items.Count; i++)
            {
                if(items[i] == _item)
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("There is no " + _item + " in my bags");//MARKER IF there is no item inside inventory
        }

        DisplayItems();
    }

}
