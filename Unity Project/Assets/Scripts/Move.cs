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
    float delta;
    float endAngle;
    
    void Start ()
    {
        Invoke("LateStart", 1f);
        
    }

    void LateStart()
    {
        cubeSelected = cube1;
        cubeSelected.Up();
        delta = endMarker.position.y - cubeSelected.transform.position.y;
    }
    void changeCube(int cubeNumber)
    {
        cubeSelected.Down();
        switch (cubeNumber)
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
        }
        cubeSelected.Up();

    }
	void Update ()
    {
        /*if (porc>10)
        {
            cubeSelected.transform.Translate(cubeSelected.transform.up * speed * Time.deltaTime * porc / 100f);
            porc = (endMarker.position.y - cubeSelected.transform.position.y) * 100 / delta;
        }*/


        if (Input.GetKeyDown(KeyCode.DownArrow))
            endAngle -=90f;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            endAngle += 90f;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            cubeSelectedNumber++;
            if (cubeSelectedNumber>4)
                cubeSelectedNumber = 4;
            changeCube(cubeSelectedNumber);
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            cubeSelectedNumber--;
            if (cubeSelectedNumber < 1)
                cubeSelectedNumber = 1;
            changeCube(cubeSelectedNumber);

        }

        if (endAngle<0)
        {
            cubeSelected.transform.Rotate(cubeSelected.transform.right, -rotationSpeed*Time.deltaTime);
            endAngle+=rotationSpeed*Time.deltaTime;
        }
        if (endAngle>0)
        {
            cubeSelected.transform.Rotate(cubeSelected.transform.right, +rotationSpeed * Time.deltaTime);
            endAngle -= rotationSpeed * Time.deltaTime;
        }
        if (endAngle>-1&&endAngle<1)
            endAngle = 0;
    }
}
