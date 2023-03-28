using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIReader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler    
{
    private GameObject mainPanel;
    public Stories[] Story;
    public Text StroryText;
    private bool _isOpen;
    private void Awake()
    {
        Story = new Stories[3];
        mainPanel = transform.GetChild(0).gameObject;
        mainPanel.SetActive(false);

       // Cursor.visible = false;
    }
    private void Update()
    {
        Reader();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isOpen = !_isOpen;
            mainPanel.gameObject.SetActive(_isOpen);
        }
      
    }
    private void Reader()
    {
        for(int i = 0; i < Story.Length; i++)
        {
            if (Story[i] == null)
            {
                Debug.LogWarningFormat("ÍÅÒÓ ÈÑÒÎÐÈÈ!");
            }
            else StroryText.text = Story[i].Story;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("IsActive");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("NotActive");
    }
}
