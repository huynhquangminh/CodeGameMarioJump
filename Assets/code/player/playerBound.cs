using UnityEngine;
using System.Collections;

public class playerBound : MonoBehaviour {


    private float minX, minY, maxX, maxY;
	// Use this for initialization
	void Start () {
        Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        minX = -bound.x + 0.3f;
        maxX = bound.x - 0.3f;
        minY = -bound.y + 0.3f;
       maxY = bound.y - 0.3f;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        if(temp.x < minX)
        {
            temp.x = minX;
        }else if(temp.x > maxX)
        {
            temp.x = maxX;
        }
        if (temp.y < minY)
        {
            temp.y = minY;
         }
        else if(temp.y > maxY)
            {
                temp.y = maxY;
            }
transform.position = temp;
	}
}
