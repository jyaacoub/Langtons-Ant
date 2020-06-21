using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    private bool centered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!centered) 
        { 
            // Bringing it to the center of the nearest tile.
            Collider[] colliders = Physics.OverlapSphere(new Vector3(0, 0, 0), 10f);

            transform.position = colliders[0].transform.position;
            print(transform.position);
            centered = true;
        }
        else
        {
            Destroy(this);
        }
    }
}
