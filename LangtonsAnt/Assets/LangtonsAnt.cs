using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LangtonsAnt : MonoBehaviour
{
    public float tileSize = GridManager.tileSize;

    // Start is called before the first frame update
    void Start()
    {
        // Bringing it to the center of the right tile.
        transform.position += new Vector3(tileSize / 2, 0, 0);
    }

    void moveRight()
    {

    }

    void moveLeft()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(tileSize, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(tileSize, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, tileSize, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, tileSize, 0);
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}
