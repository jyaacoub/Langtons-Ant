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
    }

    private void recolorTile(Color colorType, GameObject currTile)
    {
        Color color = currTile.GetComponent<Renderer>().material.color;
        //print(color);
        currTile.GetComponent<Renderer>().material.color = colorType;
    }
    
    void move(String direction)
    {
        int currAngle = (int) transform.eulerAngles.z;
        print(currAngle);

        switch (direction)
        {
            case "right":
                if (currAngle == 0)
                {
                    transform.position += new Vector3(tileSize, 0, 0);
                } 
                else if (currAngle == 90)
                {
                    transform.position += new Vector3(0, tileSize, 0);
                }
                else if (currAngle == 180)
                {
                    transform.position -= new Vector3(tileSize, 0, 0);
                }
                else if (currAngle == 270)
                {
                    transform.position -= new Vector3(0, tileSize, 0);

                }
                transform.eulerAngles -= new Vector3(0, 0, 90);
                break;
            case "left":
                if (currAngle == 0)
                {
                    transform.position -= new Vector3(tileSize, 0, 0);
                }
                else if (currAngle == 90)
                {
                    transform.position -= new Vector3(0, tileSize, 0);
                }
                else if (currAngle == 180)
                {
                    transform.position += new Vector3(tileSize, 0, 0);
                }
                else if (currAngle == 270)
                {
                    transform.position += new Vector3(0, tileSize, 0);

                }
                transform.eulerAngles += new Vector3(0, 0, 90);
                break;
            case "forwards":
                if (currAngle == 0)
                {
                    transform.position += new Vector3(0, tileSize, 0);
                }
                else if (currAngle == 90)
                {
                    transform.position -= new Vector3(tileSize, 0, 0);
                }
                else if (currAngle == 180)
                {
                    transform.position -= new Vector3(0, tileSize, 0);
                }
                else if (currAngle == 270)
                {
                    transform.position += new Vector3(tileSize, 0, 0);

                }
                break;
        }       
    }
    private GameObject getCurrentTile()
    {
        // Will only pick up the tile because they are the only things with colliders on them
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 9.9f /* Radius */);
        return colliders[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject currTile = getCurrentTile();
        Color tileColor = currTile.GetComponent<Renderer>().material.color;

        //if (tileColor == Color.white || tileColor == Color.grey)
        //{
        //    // if it reaches a white square it changes it to red and turns left.
        //    recolorTile(Color.red, currTile);
        //    move("left");

        //} 
        //else if (tileColor == Color.red)
        //{
        //    // if it reaches a red square it changes it to white and turns right.
        //    recolorTile(Color.white, currTile);
        //    move("right");
        //}

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move("right");
            recolorTile(Color.red, currTile);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move("left");
            recolorTile(Color.green, currTile);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move("forwards");
            recolorTile(Color.blue, currTile);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move("down");
            recolorTile(Color.white, currTile);

        }

    }


}


