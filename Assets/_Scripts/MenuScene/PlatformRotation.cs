using UnityEngine;


public class PlatformRotation : MonoBehaviour
{
    Quaternion nextPos;
    [SerializeField] int rotationSpeed;
    int timesRotated;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();           
    }

    void Rotate()
    {      
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {          
            timesRotated++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {           
            timesRotated--;
        }

        nextPos = Quaternion.Euler(0, 90 * timesRotated, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextPos, rotationSpeed * Time.deltaTime);
    }
}
