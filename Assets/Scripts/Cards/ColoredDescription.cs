using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColoredDescription : MonoBehaviour
{
    public TextMeshProUGUI description;
    private char[] separators = {'-', '=', '&', '$', '*'};
    private string output;

    private void Start() 
    {
        List<int> separatorIndexes = new List<int>();
        foreach (char separator in separators) 
        {
            separatorIndexes.Add(description.text.IndexOf(separator));
        }
        separatorIndexes.RemoveAll(x => x == -1);
        separatorIndexes.Sort();
        foreach (int separatorIndex in separatorIndexes) 
        {
            string color = "black";
            if (description.text[separatorIndex] == '-') 
            {
                color = "yellow";
            }
            else if (description.text[separatorIndex] == '=') 
            {
                color = "red";
            }
            else if (description.text[separatorIndex] == '$') 
            {
                color = "orange";
            }
            else if (description.text[separatorIndex] == '&') 
            {
                color = "blue";
            }
            else if (description.text[separatorIndex] == '*') 
            {
                color = "white";
            }
            if (separatorIndex == separatorIndexes.Last())
            {
                output += "<color=" + color + ">" + description.text.Substring(separatorIndex + 1) + "</color>";
            }
            else
            {
                output += "<color=" + color + ">" + description.text.Substring(separatorIndex + 1, separatorIndexes[separatorIndexes.IndexOf(separatorIndex) + 1] - 1) + "</color>";
            }
        }
        if (separatorIndexes.Count == 0)
        {
            output = description.text;
        }
        description.text = output;

        // Add enters to the description where there are \n
        description.text = description.text.Replace("\\n", "\\n\\n");
        



    }
}
