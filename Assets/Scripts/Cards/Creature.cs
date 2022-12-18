using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "Card/Creature", order = 1)]
public class Creature : Card
{
    public int attack;
    public int health;

    public string creatureClass;
    
}
