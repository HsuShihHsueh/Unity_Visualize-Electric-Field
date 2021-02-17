using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail_movement : MonoBehaviour
{
    //
    public GameObject electron1;
    public GameObject electron2;
    public GameObject trail;
    public GameObject charge_1;
    public GameObject charge_2;
    public TrailRenderer trailrender;
    public GameObject father;
    public  SliderJoint2D slider;
    bool is_finish = false;
    int self_reflash = 0;
    int tmp_charge_1 = 0;
    int tmp_charge_2 = 0;
    int parent;
    float tmp_ratio = 1f;
    Vector3 tmp_electron_position;
    Vector3 initial_position;
    Quaternion initial_quaternion;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vector3.right;
        initial_position = transform.position;
        initial_quaternion = transform.rotation;
        tmp_charge_1 = charge_1.GetComponent<charge>().sign;
        tmp_charge_2 = charge_2.GetComponent<charge>().sign;
        tmp_electron_position = electron1.transform.localPosition;
        tmp_ratio = charge_2.GetComponent<charge>().ratio;
        if (FindUpParent(gameObject.transform).name == "electron1")
        {
            parent = 1;          
        }
        else if (FindUpParent(gameObject.transform).name == "electron2")
        {
            parent = -1;
        }
        else
        {
            Debug.Log("parent error");
        }
        if (transform.name.Contains("Clone"))
        {
            transform.name = transform.name.Remove(transform.name.Length-7);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //charge change
        if(charge_1.GetComponent<charge>().sign != tmp_charge_1)
        {
            tmp_charge_1 = charge_1.GetComponent<charge>().sign;
            trail_reset();
        }
        if (charge_2.GetComponent<charge>().sign != tmp_charge_2)
        {
            tmp_charge_2 = charge_2.GetComponent<charge>().sign;
            trail_reset();
        }
        //ratio change
        if(charge_2.GetComponent<charge>().ratio != tmp_ratio)
        {
            tmp_ratio = charge_2.GetComponent<charge>().ratio;
            //Debug.Log(tmp_ratio);
            trail_reset();
        }

        if (!is_finish)
        {
            Vector3 delta_electron1 = transform.position - electron1.transform.position;
            Vector3 delta_electron2 = transform.position - electron2.transform.position;
            Vector3 sigma_e =  charge_1.GetComponent<charge>().sign * delta_electron1 / (float)Math.Pow((delta_electron1.magnitude), 3)
                            +  charge_2.GetComponent<charge>().sign * delta_electron2 / (float)Math.Pow((delta_electron2.magnitude), 3);
            if(parent == 1)
                transform.position += tmp_ratio * Vector3.Normalize(sigma_e) * Math.Abs(parent) * Math.Sign(charge_1.GetComponent<charge>().sign);
            else
                transform.position += tmp_ratio * Vector3.Normalize(sigma_e) * Math.Abs(parent) * Math.Sign(charge_2.GetComponent<charge>().sign);
            //Debug.Log(sigma_e);
        }

        //self_reflash
        if(self_reflash>60*10)
        {
            self_reflash = 0;
            trail_reset();
        }
        else
        {
            self_reflash++;
        }
        //check if electorn move
        if(electron1.transform.localPosition != tmp_electron_position)
        {
            tmp_electron_position = electron1.transform.localPosition;
            trail_reset();
        }
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("hited");
        if(collision.name == "electron2")
        {
            is_finish = true;
        }       
    }

    void trail_reset()
    {
        Instantiate(gameObject, Vector3.right, initial_quaternion,father.transform);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    Transform FindUpParent(Transform zi)
    {
        if (zi.parent == null)
            return zi;
        else
            return FindUpParent(zi.parent);
    }




}
