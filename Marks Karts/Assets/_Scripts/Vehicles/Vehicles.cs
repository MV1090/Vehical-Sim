using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    [SerializeField] WheelController[] wheelController;

    [SerializeField] float maxSpeed;    

    [SerializeField] float brakingForce;
    float currentBrakeForce;
   
    [SerializeField] float turnSensitivity;
    [SerializeField] float maxTurnAngle;
    
    Rigidbody rb;
    [SerializeField] Vector3 centerOfMass;

    private float moveInput;
    private float steerInput;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {        
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        Brake();
    }

    private void GetInput()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach (WheelController wheel in wheelController)
        {
            if (wheel.motorized)
            {
                wheel.WheelCollider.motorTorque = moveInput * 50 * maxSpeed * Time.deltaTime;
                Debug.Log(wheel.WheelCollider.motorTorque.ToString());
            }

            if (wheel.steerable)
            {
                float _steerAngle = steerInput * turnSensitivity * maxTurnAngle;
                wheel.WheelCollider.steerAngle = Mathf.Lerp(wheel.WheelCollider.steerAngle, _steerAngle, 0.6f);
            }

            wheel.WheelCollider.brakeTorque = currentBrakeForce;
        }
    }

    public virtual void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           currentBrakeForce = brakingForce;
        }

        else
        {
            currentBrakeForce = 0;
        }
    }        
    
}
