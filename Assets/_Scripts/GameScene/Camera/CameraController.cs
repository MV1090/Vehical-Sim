using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform vehicle;
    [SerializeField] CarSpawnManager car;

    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public float moveSmoothness;
    public float rotSmoothness;

    private void Start()
    {
        vehicle = car.activeCar.transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {            
        Vector3 targetPos = vehicle.TransformPoint(moveOffset);               
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);
        transform.LookAt(vehicle);
    }

    void HandleRotation()
    {        
        Vector3 direction = vehicle.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);
    }
   
}
