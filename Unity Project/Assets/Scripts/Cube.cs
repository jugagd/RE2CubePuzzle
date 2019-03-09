using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    public float verticalSpeed;
    public float maxHeight;

    float delta;
    int direction;
	// Use this for initialization
	void Start () {

        delta = maxHeight - transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (direction>0)
        {
            if (((maxHeight - transform.position.y) * 100 / delta) > 0.1f)
                transform.Translate(transform.up * verticalSpeed * Time.deltaTime * ((maxHeight - transform.position.y) * 100 / delta) / 100f);
            else
            {
                direction = 0;
            }
        }
        if (direction < 0)
        {
            if (((transform.position.y) * 100 / delta) > 0.1f)
                transform.Translate(transform.up * -verticalSpeed * Time.deltaTime * ((transform.position.y) * 100 / delta) / 100f);
            else
            {
                direction = 0;
            }
        }

    }
    public void Up()
    {
        direction = 1;
    }
    public void Down()
    {
        direction = -1;
    }
}
