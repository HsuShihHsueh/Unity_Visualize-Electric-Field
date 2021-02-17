using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron_movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localPosition =transform.localPosition + Vector3.left;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localPosition = transform.localPosition + Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localPosition = transform.localPosition + Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localPosition = transform.localPosition + Vector3.back;
        }
        if(Input.GetKey(KeyCode.Backspace))
        {
            transform.localPosition = new Vector3(10,0,0);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}
