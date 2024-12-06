using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class LineRendererScript : MonoBehaviour
{
    List<Vector3> laserPositions = new List<Vector3>();
    public GameObject laserStartObj;
    private Vector3 mouseHover;

    private LineRenderer lr;

    private float mouseMax = 5f;
    private float mouseMin = -5f;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
        laserPositions.Add(laserStartObj.transform.position);

        Debug.Log($"Laser Start is {laserStartObj}, Mouse Hover is {mouseHover}");
        
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
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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
}
