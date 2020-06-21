using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols = 8;
    [SerializeField]
    public static float tileSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referanceTile = (GameObject)Instantiate(Resources.Load("tile_white"));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referanceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
                tile.AddComponent<BoxCollider>();
                tile.GetComponent<Renderer>().material.color = Color.grey;
            }
        }

        Destroy(referanceTile);

        // Centering the grid:
        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector2((tileSize - gridWidth)/2, (gridHeight - tileSize)/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
