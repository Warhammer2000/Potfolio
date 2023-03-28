using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoyUI : MonoBehaviour
{
    public Image[] Cells;
    private SpriteRenderer render;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();    
        Cells = new Image[5];
        //for(int i = 0; i < 5; i++)
        //{
        //    Cells[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
        //}
    }


    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            Cells[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
        }
    }
}
