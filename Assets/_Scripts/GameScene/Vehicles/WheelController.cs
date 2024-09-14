using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.VehiclesModule;

public class WheelController : MonoBehaviour
{
    public Transform wheelModel;

    [HideInInspector] public WheelCollider WheelCollider;
       
    public bool steerable;
    public bool motorized;
    public bool handBreak;

    Vector3 position;
    Quaternion rotation;

    public float wheelDampening;

    // Start is called before the first frame update
    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();

        wheelDampening = WheelCollider.wheelDampingRate;
    }

    // Update is called once per frame
    void Update()
    {
        WheelCollider.GetWorldPose(out position, out rotation);
        wheelModel.transform.position = position;
        wheelModel.transform.rotation = rotation;       
    }

    

}
