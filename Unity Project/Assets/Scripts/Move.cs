using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform endMarker;
    public float speed;
    public float rotationSpeed;
    float porc=100;
    [Header("Cubes")]
    public Cube cube1;
    public Cube cube2;
    public Cube cube3;
    public Cube cube4;
    int cubeSelectedNumber = 1;
    Cube cubeSelected;
    Vector3 initalTransform;
    
    void Start ()
    {
        cubeSelected = cube1;
        cubeSelected.SelectCube();
    }

    void changeCube(int cubeNumber)
    {
        cubeSelected.DeselectCube();
        if (cube1.cubeNumber==cubeNumber)
            cubeSelected = cube1;
        if (cube2.cubeNumber == cubeNumber)
            cubeSelected = cube2;
        if (cube3.cubeNumber == cubeNumber)
            cubeSelected = cube3;
        if (cube4.cubeNumber == cubeNumber)
            cubeSelected = cube4;
        /*switch (cubeNumber)
        {
            case 1:
                cubeSelected = cube1;
                break;
            case 2:
                cubeSelected = cube2;
                break;
            case 3:
                cubeSelected = cube3;
                break;
            case 4:
                cubeSelected = cube4;
                break;
            default:
                break;
        }*/
        cubeSelected.SelectCube();
    }
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            cubeSelected.RotateCube(-90f);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            cubeSelected.RotateCube(90f);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log(cubeSelected.up);
            if (!cubeSelected.up)
            {
                cubeSelectedNumber++;
                if (cubeSelectedNumber > 4)
                    cubeSelectedNumber = 4;
                changeCube(cubeSelectedNumber);
            }
            else
            {
                if (cubeSelected.cubeNumber < 4)
                {
                    Debug.Log("Cambio");
                    cubeSelected.MoveHorizontal(1);
                    cubeSelected.cubeNumber=0;
                    cubeSelectedNumber++;
                    changeCube(cubeSelectedNumber);
                    cubeSelected.MoveHorizontal(-1);
                    cubeSelected.cubeNumber--;
                    //cubeSelectedNumber=0;
                    changeCube(0);
                    cubeSelected.cubeNumber = cubeSelectedNumber;
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log(cubeSelected.up);
            if (!cubeSelected.up)
            {
                cubeSelectedNumber--;
                if (cubeSelectedNumber < 1)
                    cubeSelectedNumber = 1;
                changeCube(cubeSelectedNumber);
            }
            else
            {
                if (cubeSelected.cubeNumber > 1)
                {
                    cubeSelected.MoveHorizontal(-1);
                    cubeSelected.cubeNumber = 0;
                    cubeSelectedNumber--;
                    changeCube(cubeSelectedNumber);
                    cubeSelected.MoveHorizontal(1);
                    cubeSelected.cubeNumber++;
                    //cubeSelectedNumber=0;
                    changeCube(0);
                    cubeSelected.cubeNumber = cubeSelectedNumber;
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cubeSelected.up)
                cubeSelected.MoveVertical(-1);
            else
                cubeSelected.MoveVertical(1);            
        }
    }
}
