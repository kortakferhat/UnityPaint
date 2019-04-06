using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    string myMode;
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "Draw")
        {
            myMode = "Draw";
        }
        else if (this.tag == "Yellow")
        {
            myMode = "Erase";
        }
    }

    void OnMouseDown()
    {
        DrawScript.currentMode = myMode;
    }
}
