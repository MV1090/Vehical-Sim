using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.chosenCar = other.gameObject.tag;       
               
    }


}
    
