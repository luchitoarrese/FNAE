using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaras : MonoBehaviour
{
    [SerializeField] private Canvas canvasOficina;
    [SerializeField] private Canvas canvasCamaras;

    [SerializeField] private Camera[] arrayCameras;
    [SerializeField] private Camera cameraActual;
    [SerializeField] private int numeroCamara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            numeroCamara += 1;
            CambioCamara(numeroCamara);
            if(numeroCamara >= 6)
            {
                CambioCamara(0);
            }
            
        }
        
    }

    public void ActivarControlDeCamaras()
    {
        
        numeroCamara = 1;
        arrayCameras[0].enabled = false;
        cameraActual = arrayCameras[1];
        cameraActual.enabled = true;
    }

    public void CambioCamara(int numeroCamaras)
    {
        cameraActual.enabled = false;
        cameraActual = arrayCameras[numeroCamaras];
        cameraActual.enabled = true;    
    }

    public void VolverOficina()
    {
        canvasCamaras.enabled = false;
        canvasOficina.enabled = true;
        arrayCameras[0].enabled = true;
        numeroCamara = 0;
        
    }
}
