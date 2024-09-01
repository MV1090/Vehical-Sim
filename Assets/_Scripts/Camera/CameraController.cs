using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform vehicle;

    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public float moveSmoothness;
    public float rotSmoothness;

   
    // Update is called once per frame
    void  FixedUpdate()
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
    }

    void HandleRotation()
    {
        Vector3 direction = vehicle.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);

    }
}
