using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DisplayDescription : MonoBehaviour
{  
    private List<string> colorIndicators = new List<string>() { "When played", "On death", "Movement" };
    private List<string> colors = new List<string>() {"#38912f", "#7d1616", "#a35721" };

    private List<string> effects = new List<string>() { "Fire", "Freeze" };
    private List<string> effectColors = new List<string>() { "#9c1313", "#27aedb" };

    public void DisplayCardDescription(List<string> attributes, TMP_Text text)
    {
        StringBuilder description = new StringBuilder();
        for (int i = 0; i < attributes.Count; i++)
        {
            string[] parts = attributes[i].Split(':');
            
            string color = "#ededed";
            foreach (string colorIndicator in colorIndicators)
            {
                if (parts[0].Contains(colorIndicator))
                {
                    color = colors[colorIndicators.IndexOf(colorIndicator)];
                }
            }
            foreach (string effect in effects)
            {
                if (parts[0].Contains(effect))
                {
                    color = effectColors[effects.IndexOf(effect)];
                }
            }
            description.Append($"<color={color}>{attributes[i]}</color>");

            if (i < attributes.Count - 1) 
            {
                description.Append("\n");
            }
        }

        text.text = description.ToString();
    }

}
