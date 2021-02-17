using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charge : MonoBehaviour
{
    public Text charge_1;
    public int sign = 1;
    public float ratio = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtn()
    {
        //Debug.Log("Click");
        string name = charge_1.text;
        string rename;
        if(name[1] == '9')
        {
            if (name[0] == '+')
                rename = "-1e";
            else
                rename = "+1e";
        }
        else
        {

            char num_0 = name[0];
            int num =  (int)name[1] + 1 - 0x30;
            rename = num_0.ToString() + num.ToString() + "e" ;
        }
        //Debug.Log(rename);
        sign = (int)rename[1] - 0x30;
        if(rename[0] == '-')
        {
            sign *= -1;
        }
        //Debug.Log("sign = "+sign);
        charge_1.text = rename;
    }

    public void ratio_change(float value)
    {
        ratio = value/100.0f;
        //Debug.Log(ratio);
    }
}
