using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class LineRendererScript : MonoBehaviour
{
    List<Vector3> laserPositions = new List<Vector3>(); // The list used for adding the positions of where the laser would go
    public GameObject laserStartObj; // The gameobject for the beginning on the laser
    public GameObject winText;
    private Vector3 mouseHover; // the vector3 variable for the movement of the mouse
    private Vector3 mouseDirection;

    private LineRenderer lr; // The variable to get the component of the linerenderer

    private float mouseMax = 5f; // The maximum float value to stop the line from going off-screen
    private float mouseMin = -5f; // the minimum float value to stop the line from going off-screen


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // Turns off the cursor
        
        laserPositions.Add(laserStartObj.transform.position); // Adds the laserStartObj position to the list
        
        lr = GetComponent<LineRenderer>(); // Gets the Linerenderer component of the game object
    }

    // Update is called once per frame
    void Update()
    {
        SetLine();
        laserPositions.Remove(mouseHover); // This removes the point the mouse is at, so it

        LineReflection(laserStartObj.transform.position, mouseDirection);


    }

    public LineRenderer SetLine()
    {
        mouseHover = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseHover.x = 8.5f;

        if (mouseHover.y >= mouseMax)
        {
            mouseHover.y = mouseMax;
        }
        else if (mouseHover.y <= mouseMin)
        {
            mouseHover.y = mouseMin;
        }

        mouseDirection = mouseHover.normalized;

        laserPositions.Add(mouseHover);

        lr.SetPositions(laserPositions.ToArray()); 

        return lr;
    }

    private Vector3 LineReflection(Vector3 laserStartObj, Vector3 mouseDirection)
    {
        Ray ray = new Ray(laserStartObj,mouseDirection);
        RaycastHit hit;

        Vector3 reflectDir;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("WinTrigger"))
            {
                Debug.Log($"");
                winText.SetActive(true);
                Time.timeScale = 0f;
            }

            if (hit.collider.CompareTag("Mirror"))
            {
                mouseHover = hit.normal;
                reflectDir = Vector3.Reflect(ray.direction, hit.normal);

                LineReflection(hit.point, reflectDir);

                return reflectDir;
            }
            else
            {
                reflectDir = Vector3.zero;

                return reflectDir;
            }
        }
        else
        {
            reflectDir = Vector3.zero;

            return reflectDir;
        }
    }
    
}
