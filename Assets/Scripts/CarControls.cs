using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{
    public float speed;
    private float reverseSpeed = 3f;
    public float turnSpeed;
    public float Horizontal;
    public float Gear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0)
        {
            speed = 0;
        }

        Horizontal = Input.GetAxis("Horizontal");
        //gas pedal
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.C) && Gear > 0)
        {
            GearsSet();
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, turnSpeed * Horizontal * Time.deltaTime);

        if (!Input.GetKey(KeyCode.W)) {
            Moving();
        }
        //reverse gear
        if(Gear==-1 && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.C)){
            transform.Translate(Vector3.back * reverseSpeed * Time.deltaTime);
        }

        //brakes
        if (Input.GetKey(KeyCode.S)) {
            if (speed > 0)
            {
                speed -= 0.35f;
            }
        }

        //Gears
            //clutch
        if (Input.GetKey(KeyCode.C))
        {
            Clutch();
        }
        //switching gears
        if (Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.LeftShift)){
            if (Gear < 5)
            {
                Gear += 1;
            }else if(Gear == 0)
            {
                Gear = 0;
            }
        }
        if(Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.LeftControl)){
            if(Gear > -1)
            {
                Gear -= 1;
            }
        }
    }
   

    public void Moving()
    {
        if (speed > 0)
        {
            speed -= 0.1f;
        }
       
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void Clutch()
    {
        if (speed > 0)
        {
            speed -= 0.06f;
        }
    }
    //gears 1-5
    public void GearsSet()
    {
        if(Gear == 1 && speed <30)
        {

            speed += 0.15f;
        }
        else if (Gear == 2 && speed < 50)
        {
            speed += 0.2f;
        }
        else if (Gear == 3 && speed < 69)
        {
            speed += 0.35f;

        }
        else if (Gear == 4 && speed < 80)
        {
            speed += 0.48f;
        }
        else if (Gear == 5 &&speed < 125)
        {
            speed += 0.55f;
        }
    }
    
}
