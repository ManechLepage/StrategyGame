using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject 
{
    public new string name;
    [TextArea(3, 10)]
    public List<string> description;
    public int cost;
    public Sprite cardImage;
    public string type;
}


