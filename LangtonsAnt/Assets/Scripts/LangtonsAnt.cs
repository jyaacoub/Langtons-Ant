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
        //print(currAngle);

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
    
    private GameObject getCurrTile()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.25f);
        GameObject currTile;

        // Create a new tile if there are none there:
        if (colliders.Length == 0)
        {
            currTile = (GameObject)Instantiate(Resources.Load("tile_white"));

            currTile.transform.position = transform.position;
            currTile.AddComponent<BoxCollider>();
            currTile.GetComponent<Renderer>().material.color = Color.grey;
        } 
        else
        {
            currTile = colliders[0].gameObject;
        }
        
        return currTile;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject currTile = getCurrTile();
        Color tileColor = currTile.GetComponent<Renderer>().material.color;

        if (tileColor == Color.white || tileColor == Color.grey)
        {
            recolorTile(Color.red, currTile);
            move("right");                           
        } 
        else if (tileColor == Color.red)
        {         
            recolorTile(Color.green, currTile);
            move("right");
        }
        else if (tileColor == Color.green)
        {
            recolorTile(Color.blue, currTile);
            move("right");
        }
        else if (tileColor == Color.blue)
        {
            recolorTile(Color.yellow, currTile);
            move("left");
        }
        else if (tileColor == Color.yellow)
        {
            recolorTile(Color.white, currTile);
            move("right");
        }

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    move("right");
        //    recolorTile(Color.red, currTile);
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    move("left");
        //    recolorTile(Color.green, currTile);
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    move("forwards");
        //    recolorTile(Color.blue, currTile);

        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    move("down");
        //    recolorTile(Color.white, currTile);

        //}

    }


}


