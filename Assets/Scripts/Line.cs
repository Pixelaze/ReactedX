using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LineColor
{
    PRIMARY,
    SECONDARY
}

public enum LineStatus
{
    OK,
    DESTROYING,
    WHITED
}

public class Line : MonoBehaviour
{
    public LineStatus status;
    public LineColor color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called 60 times per sec
    void FixedUpdate()
    {
        
    }

    void DestroyLine()
    {

    }

    void SelectLine()
    {

    }
}
