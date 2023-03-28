using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    
    [Header("UI Settings")]
    public Text ObjectName;
    public Text ObjectDesc;
    public InventoyUI invUi;
    [Header("Other Scripts")]
    public Item item;
    private Inventory inv;
    private UIReader ui;
    public Stories Stories;
    public ItemSetter setter;
    public GameObject panel;

    private void Start()
    {

        Access();
    }
    void Accccc()
    {
        int i = 0;
        object obj = i; //Boxing

        int y = (int)obj; // UnBoxing

        double pi = 3.14;
    }
    void Access()
    {
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(false);
        ObjectName.text = setter.Name;
        ObjectDesc.text = setter.Description;
        ui = GameObject.Find("Canvas").GetComponent<UIReader>();
        if (Stories)
        {
            gameObject.name = Stories.name;
        }
        else Destroy(gameObject);

    }
    private void OnMouseDown()
    {
      
        
    }
    private void OnMouseEnter()
    {
        panel.SetActive(true);
    }
    private void OnMouseExit()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        inv = other.GetComponent<Inventory>();
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            inv.AddItem(item, 12);
            ui.Story[0] = Stories;
            invUi.Cells[0].sprite = setter.ItemIcon;
            MeshRenderer render = GetComponent<MeshRenderer>();
            render.enabled = false;
        }
    }
}
