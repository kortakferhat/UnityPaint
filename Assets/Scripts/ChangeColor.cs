using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color myColor;
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "Red")
        {
            myColor = Color.red;
        }
        else if (this.tag == "Yellow")
        {
            myColor = Color.yellow;
        }
        else if (this.tag == "Blue")
        {
            myColor = Color.blue;
        }
        else if (this.tag == "Green")
        {
            myColor = Color.green;
        }
        else if (this.tag == "Black")
        {
            myColor = Color.black;
        }
    }

    void OnMouseDown()
    {
        DrawScript.currentColor = myColor;
        Debug.Log(this.tag);
    }
}
