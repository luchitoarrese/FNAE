using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBonnie : MonoBehaviour
{
    private Animator an;
    private int actionNumber = 0;
    public Transform trgt1;
    public Transform trgt2;
    public Transform trgt3;
    public Transform trgt4;
    public Transform trgt5;
    public Transform trgt6;
    public Transform trgt7;
    public Transform trgt8;
    public Transform bonnie;
    [SerializeField] private int positionValue = 0;
    [SerializeField] private bool isHunt = false;
    [SerializeField] private int radarPosition;
    [SerializeField] private bool isGoing=false;
    [SerializeField] private bool managerTime=false;
    [SerializeField] private float timerIdle=0;
    public Transform bonnieParent;
    
    void Start()
    {
        an = GetComponent<Animator>();  
        radarPosition = positionValue;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isHunt)
        {
            // Obtener una nueva posición de destino si isHunt está activo
            positionValue = Random.Range(1, 8);

            if (positionValue == 1 && radarPosition == 0)
            {
                radarPosition = 1;
                isGoing = true;
                managerTime = true;
            }
            else if(radarPosition == 1 && positionValue == 0)
            {
                radarPosition = 0;
                isGoing = true;
                managerTime = true;
            }

            else if (radarPosition == 1 && positionValue == 4)
            {
                radarPosition = 4;
                isGoing = true;
                managerTime = true;
            }
            else if(radarPosition == 4 && positionValue == 1)
            {
                radarPosition = 1;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 0 && positionValue == 2)
            {
                radarPosition = 2;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 2 && positionValue == 3)
            {
                radarPosition = 3;
                isGoing = true;
                managerTime = true;
            }
            else if(radarPosition == 3 && positionValue == 2)
            {
                radarPosition = 2;
                isGoing = true;
                managerTime = true;
            }

            else if (radarPosition == 4 && positionValue == 5)
            {
                radarPosition = 5;
                isGoing = true;
                managerTime = true;
            }
            else if(radarPosition == 5 && positionValue == 4)
            {
                radarPosition = 4;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 5 && positionValue == 6)
            {
                radarPosition = 6;
                isGoing = true;
                managerTime = true;
            }
            else if(radarPosition == 6 && positionValue == 5)
            {
                radarPosition = 5;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 5 && positionValue == 7)
            {
                radarPosition = 7;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 7 && positionValue == 5)
            {
                radarPosition = 5;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 7 && positionValue == 8)
            {
                radarPosition = 8;
                isGoing = true;
                managerTime = true;
            }
            else if (radarPosition == 8 && positionValue == 7)
            {
                radarPosition = 7;
                isGoing = true;
                managerTime = true;
            }

            // Una vez que hay un destino, detener el ciclo de caza
            if (isGoing)
            {
                an.SetInteger("Action", 1); // Activar la animación de correr
                isHunt = false; // Desactivar isHunt para que no se reinicie el ciclo
                StartMovement();
            }
        }
    }

    void StartMovement()
    {
        // Lógica de movimiento y animaciones
        switch (radarPosition)
        {
            case 1:
                if (isGoing)
                {
                    RotateToDirection(trgt1.position - bonnie.position);
                    bonnie.DOMove(trgt1.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;

            case 2:
                if (isGoing)
                {
                    RotateToDirection(trgt2.position - bonnie.position);
                    bonnie.DOMove(trgt2.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;

            case 3:
                if (isGoing)
                {
                    RotateToDirection(trgt3.position - bonnie.position);
                    bonnie.DOMove(trgt3.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;

            case 4:
                if (isGoing)
                {
                    RotateToDirection(trgt4.position - bonnie.position);
                    bonnie.DOMove(trgt4.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;
            case 5:
                if (isGoing)
                {
                    RotateToDirection(trgt5.position - bonnie.position);
                    bonnie.DOMove(trgt5.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;
            case 6:
                if (isGoing)
                {
                    RotateToDirection(trgt6.position - bonnie.position);
                    bonnie.DOMove(trgt6.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;
            case 7:
                if (isGoing)
                {
                    RotateToDirection(trgt7.position - bonnie.position);
                    bonnie.DOMove(trgt7.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;
            case 8:
                if (isGoing)
                {
                    RotateToDirection(trgt8.position - bonnie.position);
                    bonnie.DOMove(trgt8.position, 10f).OnComplete(() =>
                    {
                        FinishMovement();
                    });
                }
                break;
        }
    }

    void FinishMovement()
    {
        // Finalizar el movimiento y resetear los booleanos
        if (managerTime)
        {
            an.SetInteger("Action", 0); // Cambia a animación idle
            isGoing = false;
            managerTime = false;

            // Reactivar isHunt para iniciar un nuevo ciclo de caza

            StartCoroutine(ReactivateHunt());




        }
    }

    IEnumerator ReactivateHunt()
    {
        yield return new WaitForSeconds(4f); // Esperar 20 segundos

        isHunt = true; // Reactivar isHunt después de la espera
    }

    void RotateToDirection(Vector3 direction)
    {

        direction.Normalize();  // Normalizar el vector de dirección

        // Si el movimiento es principalmente horizontal (en el eje X)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if (direction.x < 0)
            {
                // Girar a la izquierda
                bonnie.rotation = Quaternion.Euler(0, 270, 0);  // Mira hacia la izquierda (270° en el eje Y)
            }
            else
            {
                // Girar a la derecha
                bonnie.rotation = Quaternion.Euler(0, 90, 0);  // Mira hacia la derecha (90° en el eje Y)
            }
        }
        else
        {
            // Si el movimiento es principalmente hacia adelante o hacia atrás, ajustamos esto según sea necesario.
            if (direction.z > 0)
            {
                // Mover hacia adelante
                bonnie.rotation = Quaternion.Euler(0, 0, 0);  // Mira hacia adelante (0° en el eje Y)
            }
            else
            {
                // Mover hacia atrás
                bonnie.rotation = Quaternion.Euler(0, 180, 0);  // Mira hacia atrás (180° en el eje Y)
            }
        }
    }







}

