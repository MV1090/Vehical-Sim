using UnityEngine;

public class Vehicles : MonoBehaviour
{
    [SerializeField] WheelController[] wheelController;

    [SerializeField] float maxSpeed;    

    [SerializeField] float brakingForce;
    float currentBrakeForce;
    float slipAngle;
    float brakeInput;
     
    Rigidbody rb;
    [SerializeField] Vector3 centerOfMass;

    private float moveInput;
    private float steerInput;

    private float speed;
    public AnimationCurve steeringCurve;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {       
        speed = rb.velocity.magnitude;

        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        //Brake();
    }

    private void GetInput()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        slipAngle = Vector3.Angle(transform.forward, rb.velocity);
        if (slipAngle < 120)
        {
            if (moveInput < 0)
            {
                brakeInput = Mathf.Abs(moveInput);
                moveInput = 0;
            }
            else
            {
                brakeInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
    }

    private void Move()
    {
        

        foreach (WheelController wheel in wheelController)
        {
            if (wheel.WheelCollider == null)
                return;

            if (wheel.motorized)
            {
                wheel.WheelCollider.motorTorque = moveInput * 50 * maxSpeed * Time.deltaTime;                
            }

            if (wheel.steerable)
            {
                float steeringAngle = steerInput * steeringCurve.Evaluate(speed);
                wheel.WheelCollider.steerAngle = Mathf.Lerp(wheel.WheelCollider.steerAngle, steeringAngle, 0.3f);
            }

            wheel.WheelCollider.brakeTorque = brakeInput * brakingForce;
        }
    }

    //public virtual void Brake()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //       currentBrakeForce = brakingForce;
    //    }

    //    else
    //    {
    //        currentBrakeForce = 0;
    //    }
    //}
       



}
