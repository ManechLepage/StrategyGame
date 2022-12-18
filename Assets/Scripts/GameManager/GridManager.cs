using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    public int xLength = 10;
    public int yLength = 10;
    [Space]
    public TextAsset level;
    public GameObject[,] gridArray;
    [HideInInspector]
    public GameObject[] tilePrefabs;

    private string[] generateLevel;
    private int[,] type;
    void Awake()
    {
        tilePrefabs = Resources.LoadAll<GameObject>("Tiles/Prefab");

        ReadLevel();
        xLength = Int32.Parse(generateLevel[0]);
        yLength = Int32.Parse(generateLevel[1]);
        gridArray = new GameObject[xLength, yLength];
        
        List<string[]> typeString = new List<string[]>();
        for (int i = 2; i < generateLevel.Length; i++)
        {
            typeString.Add(generateLevel[i].Split(' '));
        }
        int[,] type = new int[xLength, yLength];
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                if (typeString[x][y] != "x")
                    type[x, y] = Int32.Parse(typeString[x][y]);
                else 
                {
                    type[x, y] = -1;
                }
            }
        }
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                if (type[x, y] != -1) {
                    CreateTile(type[x, y], x, y);
                }  
            }
        }
    }

    public void ReadLevel() 
    {
        using (StreamReader sr = new StreamReader("Assets/Levels/" + level.name + ".txt"))
        {
            string line = sr.ReadToEnd();
            generateLevel = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }

    public void CreateTile(int tileType, int x, int y) 
    {
        float xPos = x * MathF.Sqrt(3) + (y % 2) * MathF.Sqrt(3) / 2;
        float yPos = y * 1.5f;
        GameObject tile = Instantiate(tilePrefabs[tileType], new Vector3(xPos - xLength / 2, 0, yPos - yLength / 2), Quaternion.identity, transform);
        tile.transform.parent = transform;
        tile.transform.Rotate(-90, 0, 0);
        tile.GetComponent<Tile>().type = tileType;
        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;
        tile.name = "Tile " + x + ", " + y;
        gridArray[x, y] = tile;
    }
}
