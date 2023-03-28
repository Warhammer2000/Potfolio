using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] item;
    public int[] count;

    private void Start()
    {
        item = new Item[15];
        count = new int[15];
    }
    public bool AddItem(Item newItem, int newcount)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] && newItem == item[i])
            {

                count[i] += newcount;
                return true;
            }

        }

        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] == null)
            {
                item[i] = newItem;
                count[i] = newcount;
                return true;
            }
        }
        return false;
    }
}
