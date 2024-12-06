using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class LineRendererScript : MonoBehaviour
{
    List<Vector3> laserPositions = new List<Vector3>();
    public GameObject laserStartObj; // The gameobject for the beginning on the laser
    private Vector3 mouseHover; // the vector3 variable for the movement of the mouse

    private LineRenderer lr; // The variable to get the component of the linerenderer

    private float mouseMax = 5f; // The maximum float value to stop the line from going off-screen
    private float mouseMin = -5f; // the minimum float value to stop the line from going off-screen


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
        laserPositions.Add(laserStartObj.transform.position);
        
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetLine();
        laserPositions.Remove(mouseHover);
    }

    private LineRenderer SetLine()
    {
        mouseHover = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseHover.x = 11f;

        if (mouseHover.y >= mouseMax)
        {
            mouseHover.y = mouseMax;
        }
        else if (mouseHover.y <= mouseMin)
        {
            mouseHover.y = mouseMin;
        }

        laserPositions.Add(mouseHover);

        lr.SetPositions(laserPositions.ToArray());

        return lr;
    }

    private LineRenderer LineReflection()
    {
    }
}
