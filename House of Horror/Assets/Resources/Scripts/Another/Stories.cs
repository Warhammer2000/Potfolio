using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Stories", fileName = "Story")]
public class Stories : ScriptableObject
{
    public string name;
    public int id;
    [TextArea(25, 15)]
    public string Story;
  
}
