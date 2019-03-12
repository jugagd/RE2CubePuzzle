using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    public float verticalSpeed;
    public float rotationSpeed;
    public float horizontalSpeed;
    public float maxHeight;
    public int cubeNumber;
    float delta;
    int verticalDirection;
    int horizontalDirection;
    float endAngle;
    float endHorizontal;
    public bool up;
    MeshRenderer ms;
    Color col;

	void Start ()
    {
#region Texture Format
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] UVs = new Vector2[mesh.vertices.Length];
        // Front
        UVs[0] = new Vector2(0.0f, 0.0f);
        UVs[1] = new Vector2(0.333f, 0.0f);
        UVs[2] = new Vector2(0.0f, 0.333f);
        UVs[3] = new Vector2(0.333f, 0.333f);
        // Top
        UVs[4] = new Vector2(0.334f, 0.333f);
        UVs[5] = new Vector2(0.666f, 0.333f);
        UVs[8] = new Vector2(0.334f, 0.0f);
        UVs[9] = new Vector2(0.666f, 0.0f);
        // Back
        UVs[6] = new Vector2(1.0f, 0.0f);
        UVs[7] = new Vector2(0.667f, 0.0f);
        UVs[10] = new Vector2(1.0f, 0.333f);
        UVs[11] = new Vector2(0.667f, 0.333f);
        // Bottom
        UVs[12] = new Vector2(0.0f, 0.334f);
        UVs[13] = new Vector2(0.0f, 0.666f);
        UVs[14] = new Vector2(0.333f, 0.666f);
        UVs[15] = new Vector2(0.333f, 0.334f);
        // Left
        UVs[16] = new Vector2(0.334f, 0.334f);
        UVs[17] = new Vector2(0.334f, 0.666f);
        UVs[18] = new Vector2(0.666f, 0.666f);
        UVs[19] = new Vector2(0.666f, 0.334f);
        // Right        
        UVs[20] = new Vector2(0.667f, 0.334f);
        UVs[21] = new Vector2(0.667f, 0.666f);
        UVs[22] = new Vector2(1.0f, 0.666f);
        UVs[23] = new Vector2(1.0f, 0.334f);
        mesh.uv = UVs;
#endregion
        delta = maxHeight - transform.position.y;
        ms = GetComponent<MeshRenderer>();
        col = ms.material.color;
        endHorizontal = transform.position.x;
    }
	
	void Update ()
    {
        //Move Up and Down
        if (verticalDirection > 0)
        {
            up = true;
            if (((maxHeight - transform.position.y) * 100 / delta) > 0.1f)
                transform.position += new Vector3(0, verticalSpeed * Time.deltaTime * ((maxHeight - transform.position.y) * 100 / delta) / 100f, 0);
            else
                verticalDirection = 0;
        }

        if (verticalDirection < 0)
        {
            up = false;
            if (((transform.position.y) * 100 / delta) > 0.1f)
                transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime * ((transform.position.y) * 100 / delta) / 100f, 0);
            else
                verticalDirection = 0;
        }

        //Hozi
        if (horizontalDirection > 0)
        {
            
            if (((endHorizontal - transform.position.x) * 100) > 0.1f)
                transform.position += new Vector3(horizontalSpeed * Time.deltaTime * ((endHorizontal - transform.position.x) * 100) / 100f, 0,0);
            else
                horizontalDirection = 0;
        }

        if (horizontalDirection < 0)
        {

            if (((transform.position.x-endHorizontal) * 100) > 0.1f)
                transform.position += new Vector3(-horizontalSpeed * Time.deltaTime * ((transform.position.x-endHorizontal) * 100) / 100f, 0, 0);
            else
                horizontalDirection = 0;
        }



        //Cube rotation
        if (endAngle < 0)
        {
            transform.Rotate(transform.right, -rotationSpeed * Time.deltaTime);
            endAngle += rotationSpeed * Time.deltaTime;
        }
        if (endAngle > 0)
        {
            transform.Rotate(transform.right, +rotationSpeed * Time.deltaTime);
            endAngle -= rotationSpeed * Time.deltaTime;
        }
        if (endAngle > -1 && endAngle < 1)
            endAngle = 0;
    } 

    public void MoveVertical(int direction)
    {
        verticalDirection = direction;
    }

    public void MoveHorizontal(int direction)
    {
            horizontalDirection = direction;
            endHorizontal += direction * 1.1f;
             

        
    }

    public void RotateCube(float angleChange)
    {
        if (up)
            endAngle += angleChange;        
    }

 #region Cube Selection
    public void SelectCube()
    {
        ms.material.color = new Color(1,0.74f,0.74f);
    }

    public void DeselectCube()
    {
        ms.material.color = col;
    }
#endregion
}
