//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    
    public Rigidbody rb;

    public GameObject chassis;
    
    public GameObject rightWheelF;
    public GameObject rightWheelB;
    public GameObject leftWheelF;
    public GameObject leftWheelB;

    public int force = 20;
    public int torque = 12;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }
    
    /*
    void PlayerMovement()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(movX,0,movY);
        rb.AddTorque(inputPlayer * speed * Time.fixedDeltaTime);
    }
    */
    
    // :: INPUTS MOVIMIENTOS ::
    void PlayerMovement()
    {
            float r = Input.GetAxis("Horizontal");
            //rb.AddTorque(new Vector3(0,torque * Time.fixedDeltaTime * r,0), ForceMode.Impulse);

            // //transform.localRotation = Quaternion.Euler(0,torque * Time.fixedDeltaTime * r,0);
            // //transform.Rotate(new Vector3(0,torque * Time.fixedDeltaTime * r,0));

            float v = Input.GetAxis("Vertical");
            //rb.AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);
            
            // //rb.AddForce(new Vector3(0,0,force * Time.fixedDeltaTime * v), ForceMode.Impulse);
            /*
            rightWheelF.GetComponent<Rigidbody>().AddTorque(new Vector3(torque * Time.fixedDeltaTime * v,0,0), ForceMode.Impulse);
            rightWheelB.GetComponent<Rigidbody>().AddTorque(new Vector3(torque * Time.fixedDeltaTime * v,0,0), ForceMode.Impulse);
            leftWheelF.GetComponent<Rigidbody>().AddTorque(new Vector3(torque * Time.fixedDeltaTime * v,0,0), ForceMode.Impulse);
            leftWheelB.GetComponent<Rigidbody>().AddTorque(new Vector3(torque * Time.fixedDeltaTime * v,0,0), ForceMode.Impulse);
            */

            //chassis.GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);

            rightWheelF.GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);
            rightWheelB.GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);
            leftWheelF.GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);
            leftWheelB.GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.fixedDeltaTime * v, ForceMode.Impulse);


    }
}

//this.gameObject.GetComponent<RigidBody>()
//gameObject.GetComponent<Rigidbody>()


/*
 Vector3 predictedUp = Quaternion.AngleAxis(shipRB.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilizationSpeed, shipRB.angularVelocity) * transform.up;
            Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
         //   torqueVector = Vector3.Project(torqueVector, transform.forward);
            shipRB.AddTorque(torqueVector * stabilizationSpeed * stabilizationSpeed);
         */