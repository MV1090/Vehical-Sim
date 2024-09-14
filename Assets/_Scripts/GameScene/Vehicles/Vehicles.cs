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
        
    public float wheelDampening;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;       
        
    }

    private void Update()
    {       
        speed = rb.velocity.magnitude;
        GetInput();

        if(Input.GetKeyDown(KeyCode.Space)) 
            FlipCar();                       
    }

    private void FixedUpdate()
    {
        Move();
        OnTrackCheck();
    }

    private void GetInput()
    {
        if (GameManager.Instance.beginRace == false)
        {
            brakeInput = 1;
            moveInput = 0;
            return;
        }
            

        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        slipAngle = Vector3.Angle(transform.forward, rb.velocity);
        
        if (slipAngle < 100)
        {
            if (moveInput < 0)
            {
                brakeInput = 1;
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

    void FlipCar()
    {                   
        if (transform.localRotation.eulerAngles.z > 90)
        {            
            Vector3 rotationToAdd = new Vector3(0, 0, 180);
            transform.Rotate(rotationToAdd);
        }
    }
       
    void OnTrackCheck()
    {
        foreach (WheelController wheel in wheelController)
        {
            
            if (wheel.WheelCollider.GetGroundHit(out WheelHit hit))
            {
                
                if (hit.collider.gameObject.name == "Grass")
                {                      
                    //isOffTrack = true;
                    if (speed > 10)
                    {
                        wheel.WheelCollider.wheelDampingRate = wheelDampening;
                    }
                    else
                        wheel.WheelCollider.wheelDampingRate = wheel.wheelDampening;
                }
                
                else
                {
                    //isOffTrack = false;

                    wheel.WheelCollider.wheelDampingRate = wheel.wheelDampening;

                }                 
                               
            }               

        }
    }      

}
