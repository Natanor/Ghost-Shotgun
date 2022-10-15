using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLine : MonoBehaviour
{
    public Vector3 endPos;
    public Vector3 startPos;
    public float moveLengthSeconds;
    private float pos = -1;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // TODO: add this movement to the player if its on the collider to remove bouncing

        pos += Time.deltaTime / moveLengthSeconds;
        transform.position = Math.Abs(pos) * startPos + (1 - Math.Abs(pos)) * endPos;
        if ( pos > 1)
        {
            pos = -1;
        }
    }
}
