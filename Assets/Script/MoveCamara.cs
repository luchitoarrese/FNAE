using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float edgeThreshold = 50f;  

    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;

        
        if (mousePosition.x <= edgeThreshold)
        {
            RotateCamera(-1); 
        }
       
        else if (mousePosition.x >= Screen.width - edgeThreshold)
        {
            RotateCamera(1); 
        }
    }

    void RotateCamera(int direction)
    {
        
        transform.Rotate(Vector3.up, direction * rotationSpeed * Time.deltaTime);
    }
}
