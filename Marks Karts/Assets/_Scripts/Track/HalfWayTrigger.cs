using UnityEngine;

public class HalfWayTrigger : MonoBehaviour
{
    [SerializeField] GameObject lapCompleteTrigger;
    [SerializeField] GameObject halfWayTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("has been triggered");
            lapCompleteTrigger.SetActive(true);
            halfWayTrigger.SetActive(false);
        }
       
       
    }


}
