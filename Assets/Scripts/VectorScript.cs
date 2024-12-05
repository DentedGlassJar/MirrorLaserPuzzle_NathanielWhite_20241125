using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorScript : MonoBehaviour
{
    public GameObject laserPointerObj;
    public GameObject goalObj;

    public LineRenderer drawLine;

    Vector2 mousePosition;
    


    // Update is called once per frame
    void Update()
    {
        OnDrawGizmos();
    }

    private void OnDrawGizmos()
    {
        mousePosition.y = Input.GetAxis("Vertical");
        
        Vector2 laserStart = laserPointerObj.transform.position;
        Vector2 laserEnd = mousePosition;

        drawLine.SetPositions(laserStart, laserEnd);

    }
}
