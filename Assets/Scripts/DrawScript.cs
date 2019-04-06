using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    // Current Mode
    public static string currentMode;
    public static Color currentColor;

    public GameObject trailPrefab;
    GameObject thisTrail;
    Vector3 startPos;
    Plane objPlane;

    // Start is called before the first frame update
    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        // Set Default Color
        currentColor = Color.black;
        // Set Default Mode
        currentMode = "Draw";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMode == "Draw")
            Draw();
        else if (currentMode == "Erase")
            Erase();
    }

    private void Erase()
    {
        //
    }

    private void Draw()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||  // For Touch Control
           Input.GetMouseButtonDown(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            trailPrefab.transform.position = Input.mousePosition;
            trailPrefab.GetComponent<TrailRenderer>().startColor = currentColor;
            trailPrefab.GetComponent<TrailRenderer>().endColor = currentColor;
            thisTrail = (GameObject)Instantiate(trailPrefab,
                                                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                                                Quaternion.identity);

            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                startPos = mRay.GetPoint(rayDistance);
            }
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) ||  // For TOUCH
            Input.GetMouseButton(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || 
            Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1f)
                Destroy(thisTrail);
        }
    }
}
