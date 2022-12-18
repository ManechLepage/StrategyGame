using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int type;
    [Space]
    [Header("Coordinates")]
    public int x;
    public int y;
    [Space]
    public bool isOccupied;
}
