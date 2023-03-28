using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemSetter" , fileName = "ItemSet")]
public class ItemSetter : ScriptableObject
{
    public string Name;
    [TextArea(10, 20)]
    public string Description;
    public Sprite ItemIcon;
  
}
